namespace OPSA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NADGrossProfits",
                c => new
                    {
                        NADId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        BiWeeklyGP = c.Double(nullable: false),
                        YTDDirectHireGP = c.Double(nullable: false),
                        YTDGPCombined = c.Double(nullable: false),
                        GPTarget = c.Double(nullable: false),
                        PercentGP = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.NADId);
            
            CreateTable(
                "dbo.TPPCGrossProfits",
                c => new
                    {
                        TPPCId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        NewGPRanking = c.Double(nullable: false),
                        BiWeekGP = c.Double(nullable: false),
                        YTDContractGP = c.Double(nullable: false),
                        YTDDirectHireGP = c.Double(nullable: false),
                        AdditionDHAllocation = c.Double(nullable: false),
                        TotalGP = c.Double(nullable: false),
                        QualifyingTotalGP = c.Double(nullable: false),
                        TotalGPTarget = c.Double(nullable: false),
                        PercentTotalGP = c.Double(nullable: false),
                        NewContractGP = c.Double(nullable: false),
                        QualifyingNewGP = c.Double(nullable: false),
                        NewGPTarget = c.Double(nullable: false),
                        PercentNewGP = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TPPCId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TPPCGrossProfits");
            DropTable("dbo.NADGrossProfits");
        }
    }
}
