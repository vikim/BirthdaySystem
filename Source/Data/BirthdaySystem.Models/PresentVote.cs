namespace BirthdaySystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PresentVote
    {
        [Key]
        [Column(Order = 0)]
        [Index("IX_PresentVotePerson", 1, IsUnique = true)]
        public int VoteId { get; set; }

        [Key]
        [Column(Order = 1)]
        [Index("IX_PresentVotePerson", 2, IsUnique = true)]
        public string UserId { get; set; }

        public int PresentId { get; set; }

        [ForeignKey("VoteId")]
        // [Index("IX_PresentVotePerson", 1, IsUnique = true)]
        public Vote Vote { get; set; }

        [ForeignKey("UserId")]
        // [Index("IX_PresentVotePerson", 2, IsUnique = true)]
        public ApplicationUser User { get; set; }

        [ForeignKey("PresentId")]
        // [Index("IX_PresentVotePerson", 3, IsUnique = true)]
        public Present Present { get; set; }

        [Required]
        public DateTime DateVote { get; set; }
    }
}
