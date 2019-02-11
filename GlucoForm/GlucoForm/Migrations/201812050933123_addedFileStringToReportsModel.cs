namespace GlucoForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedFileStringToReportsModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "ECGfile", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "ECGfile");
        }
    }
}
