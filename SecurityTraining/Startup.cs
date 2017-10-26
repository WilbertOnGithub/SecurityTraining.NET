using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SecurityTraining.Models;

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

            const string admin = "Admin";
            string[] defaultRoles = { admin, "Customer", "Sales" };

            foreach (string roleName in defaultRoles)
            {
                if (!roleManager.RoleExists(roleName))
                {
                    var role = new IdentityRole { Name = roleName };
                    roleManager.Create(role);
                }
            }

            if (context.Users.SingleOrDefault(x => x.UserName == admin) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = admin,
                    Email = "wilbert@arentheym.com"
                };

                IdentityResult result = userManager.Create(user, admin);

                //Add default User to Role Admin   
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, admin);
                }
            }
        }
    }
}
