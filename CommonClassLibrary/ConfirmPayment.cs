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
    
    public partial class ConfirmPayment
    {
        public long Id { get; set; }
        public long Id_Account { get; set; }
        public System.DateTime Date { get; set; }
        public System.TimeSpan Time { get; set; }
        public double Price { get; set; }
        public string UrlImage { get; set; }
        public string Detiail { get; set; }
        public System.DateTime CreateDate { get; set; }
        public long TicketOrder { get; set; }
        public long Id_user { get; set; }
        public int Status { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual TicketOrder TicketOrder1 { get; set; }
        public virtual UserAccount UserAccount { get; set; }
    }
}