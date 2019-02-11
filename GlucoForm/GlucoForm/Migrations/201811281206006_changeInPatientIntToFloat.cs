namespace GlucoForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeInPatientIntToFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "UmbilicalCircumference", c => c.Single(nullable: false));
            AlterColumn("dbo.Patients", "TotalCholesterole", c => c.Single(nullable: false));
            AlterColumn("dbo.Patients", "Triglicerides", c => c.Single(nullable: false));
            AlterColumn("dbo.Patients", "HDLCholesterole", c => c.Single(nullable: false));
            AlterColumn("dbo.Patients", "LDLCholesterole", c => c.Single(nullable: false));
            AlterColumn("dbo.Patients", "PRinterval", c => c.Single(nullable: false));
            AlterColumn("dbo.Patients", "QRSduration", c => c.Single(nullable: false));
            AlterColumn("dbo.Patients", "QTinterval", c => c.Single(nullable: false));
            AlterColumn("dbo.Patients", "RRinterval", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "RRinterval", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "QTinterval", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "QRSduration", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "PRinterval", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "LDLCholesterole", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "HDLCholesterole", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "Triglicerides", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "TotalCholesterole", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "UmbilicalCircumference", c => c.Int(nullable: false));
        }
    }
}
