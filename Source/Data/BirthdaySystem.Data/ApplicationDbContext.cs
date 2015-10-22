namespace BirthdaySystem.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using BirthdaySystem.Data.Migrations;
    using BirthdaySystem.Models;
    

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Present> Presents { get; set; }
        public IDbSet<Vote> Votes { get; set; }
        public IDbSet<PresentVote> PresentsVotes { get; set; }
        // public IDbSet<ApplicationUser> Users { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
