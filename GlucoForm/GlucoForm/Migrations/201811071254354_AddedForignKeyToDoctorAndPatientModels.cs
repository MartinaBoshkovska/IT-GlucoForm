namespace GlucoForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForignKeyToDoctorAndPatientModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "UserId", c => c.String());
            AddColumn("dbo.Patients", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "UserId");
            DropColumn("dbo.Doctors", "UserId");
        }
    }
}
