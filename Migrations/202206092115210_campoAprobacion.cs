namespace EasyCredit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class campoAprobacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoanAccount", "Aprobacion", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
        }
    }
}
