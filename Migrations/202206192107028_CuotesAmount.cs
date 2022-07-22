namespace EasyCredit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CuotesAmount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvestmentAccount", "CuotesAmount", c => c.Decimal());
            AddColumn("dbo.InvestmentAccount", "CuotesQuantity", c => c.Int());
        }
        
        public override void Down()
        {
        }
    }
}
