//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PharmaDAL.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerType()
        {
            this.CustomerLedger = new HashSet<CustomerLedger>();
        }
    
        public int CustomerTypeId { get; set; }
        public string CustomerType1 { get; set; }
        public string CustomerTypeShortName { get; set; }
        public bool Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerLedger> CustomerLedger { get; set; }
    }
}
