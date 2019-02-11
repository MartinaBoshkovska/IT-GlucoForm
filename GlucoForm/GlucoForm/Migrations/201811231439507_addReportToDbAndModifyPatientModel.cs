namespace GlucoForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addReportToDbAndModifyPatientModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReportId = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        ReportDate = c.DateTime(nullable: false),
                        MeasurementTime = c.DateTime(nullable: false),
                        Period = c.String(nullable: false),
                        MeasurementValue = c.String(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.ReportId)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
            AddColumn("dbo.Patients", "HighBloodPreasure", c => c.String());
            AddColumn("dbo.Patients", "knownDiabetesOrAbnormalGlucose", c => c.String());
            AddColumn("dbo.Patients", "DiabetesMellitusInFamily", c => c.Boolean(nullable: false));
            AddColumn("dbo.Patients", "AlcoholConsumption", c => c.String());
            AddColumn("dbo.Patients", "SmokingHabbits", c => c.String());
            AddColumn("dbo.Patients", "physicalActivity", c => c.String());
            AddColumn("dbo.Patients", "BMI", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "UmbilicalCircumference", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "Medications", c => c.String());
            AddColumn("dbo.Patients", "AdditionalInformation", c => c.String());
            AddColumn("dbo.Patients", "TotalCholesterole", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "Triglicerides", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "HDLCholesterole", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "LDLCholesterole", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "PRinterval", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "QRSduration", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "QTinterval", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "RRinterval", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "PatientId", "dbo.Patients");
            DropIndex("dbo.Reports", new[] { "PatientId" });
            DropColumn("dbo.Patients", "RRinterval");
            DropColumn("dbo.Patients", "QTinterval");
            DropColumn("dbo.Patients", "QRSduration");
            DropColumn("dbo.Patients", "PRinterval");
            DropColumn("dbo.Patients", "LDLCholesterole");
            DropColumn("dbo.Patients", "HDLCholesterole");
            DropColumn("dbo.Patients", "Triglicerides");
            DropColumn("dbo.Patients", "TotalCholesterole");
            DropColumn("dbo.Patients", "AdditionalInformation");
            DropColumn("dbo.Patients", "Medications");
            DropColumn("dbo.Patients", "UmbilicalCircumference");
            DropColumn("dbo.Patients", "BMI");
            DropColumn("dbo.Patients", "physicalActivity");
            DropColumn("dbo.Patients", "SmokingHabbits");
            DropColumn("dbo.Patients", "AlcoholConsumption");
            DropColumn("dbo.Patients", "DiabetesMellitusInFamily");
            DropColumn("dbo.Patients", "knownDiabetesOrAbnormalGlucose");
            DropColumn("dbo.Patients", "HighBloodPreasure");
            DropTable("dbo.Reports");
        }
    }
}
