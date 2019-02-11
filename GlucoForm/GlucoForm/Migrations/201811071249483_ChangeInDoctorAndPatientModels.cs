namespace GlucoForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInDoctorAndPatientModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Gender", c => c.String(nullable: false));
            AddColumn("dbo.Doctors", "TelephoneNumber", c => c.String(nullable: false));
            AddColumn("dbo.Patients", "profession", c => c.String());
            AlterColumn("dbo.Doctors", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "TelephoneNumber", c => c.String(nullable: false));
            DropColumn("dbo.Doctors", "Telephone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "Telephone", c => c.String());
            AlterColumn("dbo.Patients", "TelephoneNumber", c => c.String());
            AlterColumn("dbo.Patients", "Email", c => c.String());
            AlterColumn("dbo.Patients", "Gender", c => c.String());
            AlterColumn("dbo.Patients", "Surname", c => c.String());
            AlterColumn("dbo.Patients", "Name", c => c.String());
            AlterColumn("dbo.Doctors", "Email", c => c.String());
            AlterColumn("dbo.Doctors", "Surname", c => c.String());
            AlterColumn("dbo.Doctors", "Name", c => c.String());
            DropColumn("dbo.Patients", "profession");
            DropColumn("dbo.Doctors", "TelephoneNumber");
            DropColumn("dbo.Doctors", "Gender");
        }
    }
}
