namespace OPSA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recruiting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MonthlyRecruitings",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        RankDifference = c.Int(nullable: false),
                        PreviousRank = c.Int(nullable: false),
                        CompanyRank = c.Int(nullable: false),
                        PositionRank = c.Int(nullable: false),
                        Score = c.Double(nullable: false),
                        Total4WKStarts = c.Double(nullable: false),
                        CurrentHeadCount = c.Double(nullable: false),
                        MonthHCGoal = c.Double(nullable: false),
                        Prescreens = c.Double(nullable: false),
                        Sendouts = c.Double(nullable: false),
                        ClientVisits = c.Double(nullable: false),
                        NewPositions = c.Double(nullable: false),
                        PercentExpectations = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MonthlyRecruitings");
        }
    }
}
