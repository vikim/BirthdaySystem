namespace BirthdaySystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Vote
    {
        [Key]
        public int Id { get; set; }

        //public string InitiatorId { get; set; }
        public ApplicationUser Initiator { get; set; }

        [Index("IX_FirstAndSecond", 1, IsUnique = true)]
        public ApplicationUser Aim { get; set; }

        //public string AimId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Index("IX_FirstAndSecond", 2, IsUnique = true)]
        public int Year { get; set; }
    }
}
