namespace GlucoForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForignKeyToDoctorAndPatientModelsTry2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Patients", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Doctors", "UserId");
            CreateIndex("dbo.Patients", "UserId");
            AddForeignKey("dbo.Doctors", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Patients", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Doctors", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Patients", new[] { "UserId" });
            DropIndex("dbo.Doctors", new[] { "UserId" });
            AlterColumn("dbo.Patients", "UserId", c => c.String());
            AlterColumn("dbo.Doctors", "UserId", c => c.String());
        }
    }
}
