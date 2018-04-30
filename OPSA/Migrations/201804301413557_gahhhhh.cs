namespace OPSA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gahhhhh : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MonthlyRecruitings", "RankDifference", c => c.Double(nullable: false));
            AlterColumn("dbo.MonthlyRecruitings", "PreviousRank", c => c.Double(nullable: false));
            AlterColumn("dbo.MonthlyRecruitings", "CompanyRank", c => c.Double(nullable: false));
            AlterColumn("dbo.MonthlyRecruitings", "PositionRank", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MonthlyRecruitings", "PositionRank", c => c.Int(nullable: false));
            AlterColumn("dbo.MonthlyRecruitings", "CompanyRank", c => c.Int(nullable: false));
            AlterColumn("dbo.MonthlyRecruitings", "PreviousRank", c => c.Int(nullable: false));
            AlterColumn("dbo.MonthlyRecruitings", "RankDifference", c => c.Int(nullable: false));
        }
    }
}
