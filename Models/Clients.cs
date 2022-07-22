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
    
    public partial class Clients
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clients()
        {
            this.InvestmentAccount = new HashSet<InvestmentAccount>();
            this.LoanAccount = new HashSet<LoanAccount>();
            this.LoanAccount1 = new HashSet<LoanAccount>();
            this.SavingAccounts = new HashSet<SavingAccounts>();
            this.Transactions = new HashSet<Transactions>();
        }
    
        public int Id { get; set; }
        public string Cte_FirstName { get; set; }
        public string Cte_LastName { get; set; }
        public string Cte_Cedula { get; set; }
        public string Cte_Address { get; set; }
        public string Cte_Phone { get; set; }
        public string RegisteredBy { get; set; }
        public System.DateTime RegistrationDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvestmentAccount> InvestmentAccount { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoanAccount> LoanAccount { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoanAccount> LoanAccount1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SavingAccounts> SavingAccounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
