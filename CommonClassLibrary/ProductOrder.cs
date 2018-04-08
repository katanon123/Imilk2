//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CommonClassLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductOrder
    {
        public int Id { get; set; }
        public long TicketOrder { get; set; }
        public long Product { get; set; }
        public decimal Quantity { get; set; }
        public string Remark { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public int Status { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Total { get; set; }
    
        public virtual Product Product1 { get; set; }
        public virtual TicketOrder TicketOrder1 { get; set; }
        public virtual UserAccount UserAccount { get; set; }
    }
}
