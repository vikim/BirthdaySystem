namespace BirthdaySystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Present
    {
        private ICollection<PresentVote> presentsVotes;

        public Present()
        {
            this.presentsVotes = new HashSet<PresentVote>();
        }
        
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<PresentVote> PresentsVotes
        {
            get { return this.presentsVotes; }
            set { this.presentsVotes = value; }
        }
    }
}
