namespace BirthdaySystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PresentVote
    {
        [Key]
        [Column(Order = 0)]
        public int VoteId { get; set; }

        public Vote Vote { get; set; }

        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        //public int PresentId { get; set; }
        public Present Present { get; set; }

        public DateTime DateVote { get; set; }
    }
}
