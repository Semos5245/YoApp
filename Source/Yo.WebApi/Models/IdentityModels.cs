using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Yo.Models;

namespace Yo.WebApi.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DatabaseConnection", throwIfV1Schema: false)
        {
        }

        public new DbSet<User> Users { get; set; }

        public DbSet<FriendsRequest> FriendsRequests { get; set; }

        public DbSet<Yo.Models.Yo> Yos { get; set; }

        public DbSet<FriendRelation> FriendRelations { get; set; }


        protected override void OnModelCreating(DbModelBuilder builder)
        {
            //builder.Entity<FriendRelation>().HasKey(f => new { f.CurrentUserId, f.FriendUserId });
            //builder.Entity<FriendRelation>()
            //    .HasRequired(f => f.CurrentUser)
            //    .WithMany(b => b.)
            //    .HasForeignKey(f => f.CurrentUserId);
            //builder.Entity<FriendRelation>().HasRequired(f => f.FriendUser)
            //    .WithMany()
            //    .HasForeignKey(f => f.FriendUserId)
            //    .WillCascadeOnDelete(false);
            base.OnModelCreating(builder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}