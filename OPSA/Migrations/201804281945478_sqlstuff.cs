namespace OPSA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sqlstuff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Tenure", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Tenure", c => c.Int(nullable: false));
        }
    }
}
