using GlucoForm.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GlucoForm.Startup))]
namespace GlucoForm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRoles();
        }

        private void createRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Doctor"))
            {
                var role = new IdentityRole();
                role.Name = "Doctor";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Patient"))
            {
                var role = new IdentityRole();
                role.Name = "Patient";
                roleManager.Create(role);
            }


        }
    }
}
