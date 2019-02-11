namespace GlucoForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeInPatientBoolToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "DiabetesMellitusInFamily", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "DiabetesMellitusInFamily", c => c.Boolean(nullable: false));
        }
    }
}
