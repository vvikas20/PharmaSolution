using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PharmaUI
{
    public static class StagingData
    {
        public static DataTable ItemList { get; set; }

        public static void SetItemListData(DataTable _ItemList)
        {
            DataView dv = _ItemList.DefaultView;
            dv.Sort = "ItemName";
            ItemList = dv.ToTable();
        }

    }
}
