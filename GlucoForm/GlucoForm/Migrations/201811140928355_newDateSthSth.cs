namespace GlucoForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDateSthSth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "DateOfInclusionInTheStudy", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "DateOfInclusionInTheStudy", c => c.DateTime(nullable: false));
        }
    }
}
