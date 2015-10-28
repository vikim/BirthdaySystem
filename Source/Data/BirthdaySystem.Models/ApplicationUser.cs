namespace BirthdaySystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    // http://www.entityframeworktutorial.net/code-first/configure-entity-mappings-using-fluent-api.aspx
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        private ICollection<PresentVote> presentsVotes;
        private ICollection<Vote> organisedVotes;

        public ApplicationUser()
        {
            this.presentsVotes = new HashSet<PresentVote>();
            this.organisedVotes = new HashSet<Vote>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //[Column(TypeName = "datetime2")]
        public DateTime? Birthdate { get; set; }

        public string Name
        {
            get
            {
                return this.FirstName + "  " + this.LastName;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<PresentVote> PresentsVotes
        {
            get { return this.presentsVotes; }
            set { this.presentsVotes = value; }
        }

        public virtual ICollection<Vote> OrganisedVotes
        {
            get { return this.organisedVotes; }
            set { this.organisedVotes = value; }
        }
    }
}
