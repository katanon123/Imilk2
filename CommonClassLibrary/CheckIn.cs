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
    
    public partial class CheckIn
    {
        public long Id { get; set; }
        public long TicketOrder { get; set; }
        public string Remark { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public int Status { get; set; }
        public long CreatedBy { get; set; }
    
        public virtual TicketOrder TicketOrder1 { get; set; }
        public virtual UserAccount UserAccount { get; set; }
    }
}
