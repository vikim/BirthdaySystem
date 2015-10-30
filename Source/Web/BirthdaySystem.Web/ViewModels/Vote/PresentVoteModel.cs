namespace BirthdaySystem.Web.ViewModels.Vote
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using BirthdaySystem.Models;
    using BirthdaySystem.Web.Infrastructure.Mapping;
    
    public class PresentVoteModel : IMapFrom<PresentVote>
    {
        public int VoteId { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Present")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Choose a present from the list")]
        public int PresentId { get; set; }

        //[Display(Name = "Present")]
        //[Required]
        //public string Present { get; set; }

        //public IEnumerable<SelectListItem> Presents { get; set; }

        public DateTime DateVote { get; set; }

        [Display(Name = "Birthday for")]
        public string BirthdayPerson { get; set; }
    }
}