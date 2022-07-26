//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EasyCredit.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvestmentAccount
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public string Code { get; set; }
        public decimal InvestementAmount { get; set; }
        public decimal MonthlyRevenue { get; set; }
        public int PayMethodeId { get; set; }
        public string Especificaciones { get; set; }
        public System.DateTime DateInvestment { get; set; }
        public string RegisteredBy { get; set; }
        public Nullable<decimal> CuotesAmount { get; set; }
        public Nullable<int> CuotesQuantity { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual PayMethodes PayMethodes { get; set; }
    }
}
