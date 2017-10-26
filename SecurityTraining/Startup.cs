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
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            const string admin = "Admin";

            if (!roleManager.RoleExists(admin))
            {

                // first we create Admin rool   
                var role = new IdentityRole { Name = admin };
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser
                {
                    UserName = admin,
                    Email = "wilbert@arentheym.com"
                };

                IdentityResult result = UserManager.Create(user, admin);

                //Add default User to Role Admin   
                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, admin);
                }
            }
        }
    }
}
