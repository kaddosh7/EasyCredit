﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EasyCreditEntities : DbContext
    {
        public EasyCreditEntities()
            : base("name=EasyCreditEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<InvestmentAccount> InvestmentAccount { get; set; }
        public virtual DbSet<LoanAccount> LoanAccount { get; set; }
        public virtual DbSet<PayMethodes> PayMethodes { get; set; }
        public virtual DbSet<SavingAccounts> SavingAccounts { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<TypeTransaction> TypeTransaction { get; set; }
        public virtual DbSet<Warranty> Warranty { get; set; }
    }
}