namespace BirthdaySystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public class Vote
    {
        private ICollection<PresentVote> presentsVotes;

        public Vote()
        {
            this.presentsVotes = new HashSet<PresentVote>();
        }

        [Key]
        public int Id { get; set; }

        public string InitiatorId { get; set; }

        //[Required]
        [ForeignKey("InitiatorId")]
        public ApplicationUser Initiator { get; set; }

        [Index("IX_OneBirthdayVotePerPersonPerYear", 2, IsUnique = true)]
        public string BirthdayPersonId { get; set; }

        // [Required]
        [ForeignKey("BirthdayPersonId")]
        public ApplicationUser BirthdayPerson { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        [Index("IX_OneBirthdayVotePerPersonPerYear", 1, IsUnique = true)]
        public int Year { get; set; }

        public virtual ICollection<PresentVote> PresentsVotes
        {
            get { return this.presentsVotes; }
            set { this.presentsVotes = value; }
        }
    }
}
