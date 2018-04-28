using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OPSA.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class OPSAEntities : IdentityDbContext<ApplicationUser>
    {
        public OPSAEntities()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static OPSAEntities Create()
        {
            return new OPSAEntities();
        }

        public System.Data.Entity.DbSet<OPSA.Models.Events> Events { get; set; }

        public System.Data.Entity.DbSet<OPSA.Models.Employee> Employee { get; set; }
    }
}