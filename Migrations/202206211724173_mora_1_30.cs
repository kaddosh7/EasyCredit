namespace EasyCredit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mora_1_30 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "nivel_mora", c => c.Decimal());
            AddColumn("dbo.Transactions", "mora", c => c.Decimal());
        }
        
        public override void Down()
        {
        }
    }
}
