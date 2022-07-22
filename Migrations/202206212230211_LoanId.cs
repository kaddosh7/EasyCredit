namespace EasyCredit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoanId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "LoanId", c => c.Int());
        }
        
        public override void Down()
        {
        }
    }
}
