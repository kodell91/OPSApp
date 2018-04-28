using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using OPSA.Models;

[assembly: OwinStartupAttribute(typeof(OPSA.Startup))]
namespace OPSA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        public void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleAdminRole = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleAdminUser = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleAdminRole.RoleExists("SuperUser"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "SuperUser";
                roleAdminRole.Create(role);
                var user = new ApplicationUser();
                user.Email = "adming@gmail.com";
                string userPWD = "Password1!";
                var chkUser = roleAdminUser.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = roleAdminUser.AddToRole(user.Id, "SuperUser");
                }
            }
        }
    }
}
