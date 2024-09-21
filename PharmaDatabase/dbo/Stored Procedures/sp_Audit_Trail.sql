CREATE PROCEDURE [dbo].[sp_Audit_Trail] (@TableName Varchar(128),@columnUpdate varbinary(10))   
AS   
    
DECLARE @flag int   
    
 --SELECT @flag= flag FROM AuditBulkController   
 --IF(@flag=0)   
 --BEGIN   
 -- RETURN   
 --END   
    
DECLARE @bit int ,   
@field int ,   
@maxfield int ,   
@char int ,   
@fieldname varchar(128) ,   
@fielddatatype varchar(128) ,   
@PKCols varchar(1000) ,   
@sql varchar(2000),    
@UpdateDate varchar(21) ,   
@UserName varchar(128) ,   
@Type char(1) ,   
@PKSelect varchar(1000),   
@UpdatedBy varchar(100),   
@result varchar(1000),   
@Audit_Enabled BIT   
     
set @Type='I'   
  
SET NOCOUNT ON; 
  
SELECT ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS RowID, * into #insertedRows from #inserted 
SELECT ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS RowID, * into #deletedRows from #deleted  
  
DECLARE @RowID INT = 1, @InsertRowCount INT = 0, @DeleteRowCount INT = 0 
  
SELECT @InsertRowCount = COUNT(*) From #insertedRows 
SELECT @DeleteRowCount = COUNT(*) From #deletedRows 
  
WHILE((@RowID <= @InsertRowCount AND @InsertRowCount <> 0) OR (@RowID <= @DeleteRowCount AND @DeleteRowCount <> 0)) 
BEGIN 
  
 if exists (select * from #insertedRows WHERE RowID = @RowID)   
  if exists (select * from #deletedRows WHERE RowID = @RowID)   
  BEGIN   
   select @Type = 'U'   
   select  @UserName = ModifiedBy from #insertedRows WHERE RowID = @RowID  
  end   
  else   
  begin   
   select @Type = 'I'   
   select  @UserName = CreatedBy from #insertedRows WHERE RowID = @RowID   
  end   
 else   
 begin   
  select @Type = 'D'   
  set @UserName = system_user     
 END   
  
 Print @Type 
   
 -- date and user    
      
 select @UpdateDate = convert(varchar(21), GETDATE())  
 -- Get primary key select for insert   
 DECLARE @sqlString VARCHAR(2000)   
 SELECT @PKSelect = NULL, @PKCols = NULL  
   
 IF @type='I'   
 BEGIN    
  print 'Insert PK'   
  DECLARE @sqlstr nvarchar(max)   
  
  select @PKSelect = coalesce(@PKSelect+'+','') + '''<' + COLUMN_NAME + '=''+convert(varchar(100),coalesce(i.' + COLUMN_NAME +',''''))+''>'''    
  from INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk ,   
  INFORMATION_SCHEMA.KEY_COLUMN_USAGE c   
  where  pk.TABLE_NAME = @TableName   
  and CONSTRAINT_TYPE = 'PRIMARY KEY'   
  and c.TABLE_NAME = pk.TABLE_NAME   
  and c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME    
  
  SET @sqlstr='select @x = '+ @PKSelect+ ' from #insertedRows i Where RowID = ' + CONVERT(VARCHAR,@RowID)   
  
  exec sp_executesql @sqlstr, N'@x VARCHAR(max) out', @PKSelect OUT   
 END   
   
 -- Get primary key select for insert   
 IF @type='D'   
 BEGIN   
  select @PKSelect = coalesce(@PKSelect+'+','') + '''<' + COLUMN_NAME + '=''+convert(varchar(100),coalesce(d.' + COLUMN_NAME +',''''))+''>'''    
  from INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk ,   
  INFORMATION_SCHEMA.KEY_COLUMN_USAGE c   
  where  pk.TABLE_NAME = @TableName   
  and CONSTRAINT_TYPE = 'PRIMARY KEY'   
  and c.TABLE_NAME = pk.TABLE_NAME   
  and c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME    
  
  SET @sqlstr='select @x = '+ @PKSelect+ ' from #deletedRows d Where RowID = ' + CONVERT(VARCHAR,@RowID)   
  
  exec sp_executesql @sqlstr, N'@x VARCHAR(max) out', @PKSelect out   
 END   
  
 -- Get primary key select for insert   
 IF @type='U'   
 BEGIN   
  select @PKSelect = coalesce(@PKSelect+'+','') + '''<' + COLUMN_NAME + '=''+convert(varchar(100),coalesce(i.' + COLUMN_NAME +',d.' + COLUMN_NAME + '))+''>'''    
  from INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk ,   
  INFORMATION_SCHEMA.KEY_COLUMN_USAGE c   
  where  pk.TABLE_NAME = @TableName   
  and CONSTRAINT_TYPE = 'PRIMARY KEY'   
  and c.TABLE_NAME = pk.TABLE_NAME   
  and c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME    
 END 
   
 IF @type='I'   
 BEGIN   
  print 'Insert Audit'   
  DECLARE @x1 XML   
  SELECT @x1 = (select * from #insertedRows as RowAuditData WHERE RowID = @RowID for xml AUTO, ELEMENTS)  
    
  IF (@x1 IS NOT NULL AND @x1.exist('/RowAuditData/RowID') = 1) 
   SET @x1.modify('delete /RowAuditData/RowID') 
    
  INSERT INTO  AuditHistory (CreatedAt,UserName,TableName,ColumnName,OldValue,NewValue,Operation,PrimaryKey)   
  VALUES(GETDATE(), @UserName, @TableName,'Insert', NULL, Convert(varchar(max),@x1),@type,@PKSelect)   
  
 END    
   
 IF @type='D'   
 BEGIN   
  DECLARE @x2 XML   
  SELECT @x2 = (select * from #deletedRows as RowAuditData WHERE RowID = @RowID for xml AUTO, ELEMENTS)   
    
  IF (@x2 IS NOT NULL AND @x2.exist('/RowAuditData/RowID') = 1) 
   SET @x2.modify('delete /RowAuditData/RowID') 
    
  INSERT INTO  AuditHistory (CreatedAt,UserName,TableName,ColumnName,OldValue,NewValue,Operation,PrimaryKey)   
  VALUES(GETDATE(), @UserName, @TableName,'Delete', Convert(varchar(max),@x2),null,@type,@PKSelect)     
  
 END    
   
 IF @type='U'   
 BEGIN   
  
  -- Get primary key columns for full outer join   
  select @PKCols = coalesce(@PKCols + ' and', ' on') + ' i.' + c.COLUMN_NAME + ' = d.' + c.COLUMN_NAME   
  from INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk ,   
  INFORMATION_SCHEMA.KEY_COLUMN_USAGE c   
  where  pk.TABLE_NAME = @TableName   
  and CONSTRAINT_TYPE = 'PRIMARY KEY'   
  and c.TABLE_NAME = pk.TABLE_NAME   
  and c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME   
  
  if @PKCols is null   
  begin   
   raiserror('no PK on table %s', 16, -1, @TableName)   
   return   
  END   
  
  
  select @field = 0,  
  @maxfield = max(COLUMNPROPERTY(object_id(table_schema+'.'+table_name),column_name,'columnid'))  
  from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @TableName   
  
  while @field < @maxfield   
  begin   
   select @field = min(COLUMNPROPERTY(object_id(table_schema+'.'+table_name),column_name,'columnid'))  
   from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @TableName  
   and COLUMNPROPERTY(object_id(table_schema+'.'+table_name),column_name,'columnid')  > @field 
  
  
   select @bit = (@field - 1 )% 8 + 1   
   select @bit = power(2,@bit - 1)   
   select @char = ((@field - 1) / 8) + 1   
     
   select @fieldname = COLUMN_NAME, 
   @fielddatatype=UPPER(DATA_TYPE)  
   from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @TableName  
   and COLUMNPROPERTY(object_id(table_schema+'.'+table_name),column_name,'columnid') = @field   
     
   -- check field we want to exclude it for auditing   
   if (substring(@columnUpdate,@char, 1) & @bit > 0 )or @Type in ('I','D')   
   BEGIN  
      
    IF @fielddatatype='TEXT' OR @fielddatatype ='NTEXT' OR @fielddatatype='IMAGE'   
    BEGIN   
     DECLARE @sqlstr1 nvarchar(max)   
     DECLARE @sqlstr2 nvarchar(max)   
  
     SET @PKSelect = REPLACE(@PKSelect,'d.' ,'i.')   
     SET @sqlstr1='select @x = '+ @PKSelect+ ' from #insertedRows i Where RowID = ' + CONVERT(VARCHAR,@RowID)   
  
     exec sp_executesql @sqlstr1, N'@x VARCHAR(max) out', @PKSelect OUT          
  
     INSERT INTO  AuditHistory (CreatedAt,UserName,TableName,ColumnName,OldValue,NewValue,Operation,PrimaryKey)   
     VALUES(GETDATE(), @UserName, @TableName,@fieldname, @fielddatatype,@fielddatatype,@type,@PKSelect)   
    END   
    ELSE   
    BEGIN  
     /* Code for generating UPDATE (or insert and delete) syntaxes */   
     select @sql =   'insert AuditHistory (Operation,TableName,PrimaryKey,ColumnName,OldValue,NewValue,CreatedAt,UserName)'   
     select @sql = @sql +  ' select ''' + @Type + ''''   
     select @sql = @sql +  ',''' + @TableName + ''''   
     select @sql = @sql +  ',' + @PKSelect   
     select @sql = @sql +  ',''' + @fieldname + ''''   
     select @sql = @sql +  ',convert(varchar(1000),d.' + @fieldname + ')'   
     select @sql = @sql +  ',convert(varchar(1000),i.' + @fieldname + ')'   
     select @sql = @sql +  ',''' + @UpdateDate + ''''   
     select @sql = @sql +  ',''' + @UserName + ''''   
     select @sql = @sql +  ' from #insertedRows i full outer join #deletedRows d'   
     select @sql = @sql +  @PKCols    
     select @sql = @sql +  ' where i.' + @fieldname + ' <> d.' + @fieldname    
     select @sql = @sql +  ' or (i.' + @fieldname + ' is null and  d.' + @fieldname + ' is not null)'    
     select @sql = @sql +  ' or (i.' + @fieldname + ' is not null and  d.' + @fieldname + ' is null)'  
     select @sql = @sql +  ' and (i.RowID = ' + CONVERT(VARCHAR,@RowID) + ')'  
     exec (@sql) 
     print @rowID 
     print @PKSelect 
     print @sql 
    end     
   end   
       
  end   
 END 
     
 SET @RowID = @RowID  + 1 
   
END 
SET NOCOUNT OFF;
