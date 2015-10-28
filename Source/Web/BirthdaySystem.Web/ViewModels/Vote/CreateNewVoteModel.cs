namespace BirthdaySystem.Web.ViewModels.Vote
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using BirthdaySystem.Models;
    using BirthdaySystem.Web.Infrastructure.Mapping;
    using BirthdaySystem.Web.Infrastructure.Populators;

    public class CreateNewVoteModel : IMapFrom<Vote>
    {
        // http://nimblegecko.com/using-simple-drop-down-lists-in-ASP-NET-MVC/
        [Required]
        [Display(Name = "Birthday vote for")]
        public string BirthdayPerson { get; set; }

        public IEnumerable<SelectListItem> BirthdayPeople { get; set; }

        [Required]
        [Display(Name = "Vote Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Vote End Date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [Required]
        [Display(Name = "Year")]
        public int Year { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Vote, CreateNewVoteModel>()
                .ForMember(p => p.BirthdayPerson, opt => opt.MapFrom(p => p.BirthdayPerson.FirstName))
                .ReverseMap();
        }
    }
}