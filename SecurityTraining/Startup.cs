using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SecurityTraining.Models;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(SecurityTraining.Startup))]
namespace SecurityTraining
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            CreateDefaultRolesAndUsers();
        }

        private void CreateDefaultRolesAndUsers()                                                             
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            const string defaultSalesPersonName = "wilbert@arentheym.com";

            const string salesPerson = "Sales";
            const string contact = "Contact";
            string[] defaultRoles = { contact, salesPerson };

            foreach (string roleName in defaultRoles)
            {
                if (!roleManager.RoleExists(roleName))
                {
                    var role = new IdentityRole { Name = roleName };
                    roleManager.Create(role);
                }
            }

            // Create default sales person with rights to login.
            if (context.Users.SingleOrDefault(x => x.UserName == defaultSalesPersonName) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = defaultSalesPersonName,
                    Email = defaultSalesPersonName
                };

                IdentityResult result = userManager.Create(user, "password");
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, salesPerson);
                }
            }
        }
    }
}
