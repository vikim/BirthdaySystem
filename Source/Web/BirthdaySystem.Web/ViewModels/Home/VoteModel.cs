namespace BirthdaySystem.Web.ViewModels.Home
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BirthdaySystem.Models;
    using BirthdaySystem.Web.Infrastructure.Mapping;

    public class VoteModel : IMapFrom<Vote>
    {
        public int Id { get; set; }

        [Display(Name = "Vote Initiator")]
        public ApplicationUser Initiator { get; set; }

        [Display(Name = "Birthday for")]
        public ApplicationUser BirthdayPerson { get; set; }

        [Display(Name = "Vote Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Vote End Date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Year")]
        public int Year { get; set; }
    }
}