namespace BirthdaySystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Microsoft.AspNet.Identity;

    using BirthdaySystem.Data.Common.Data;
    using BirthdaySystem.Data.Common.Services.Contracts;
    using BirthdaySystem.Web.Infrastructure.Populators;
    using BirthdaySystem.Web.ViewModels.Vote;
    using BirthdaySystem.Models;

    public class VoteController : Controller
    {
        private IBirthdayPeopleService birthdayData;
        private IVoteService voteData;
        private readonly IBirthdayData dbData;

        public VoteController(IBirthdayPeopleService birthdayPeople, IVoteService voteData, IBirthdayData dbData)
        {
            this.birthdayData = birthdayPeople;
            this.voteData = voteData;
            this.dbData = dbData;
        }

        [HttpGet]
        [Authorize]
        // [PopulateBirthdayPeople]
        //[ValidateAntiForgeryToken]
        // GET: Vote
        public ActionResult CreateVote()
        {
            // http://stackoverflow.com/questions/18448637/how-to-get-current-user-and-how-to-use-user-class-in-mvc5
            var birtdayPeople = this.birthdayData
                .GetAllBirthdayPeople(this.User.Identity.GetUserId())
                .ToList();

            var model = new CreateNewVoteModel();

            model.BirthdayPeople = new SelectList(birtdayPeople, "Id", "Name");

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult CreateVote(CreateNewVoteModel input)
        {
            var birtdayPeople = this.birthdayData
                .GetAllBirthdayPeople(this.User.Identity.GetUserId())
                .ToList();

            input.BirthdayPeople = new SelectList(birtdayPeople, "Id", "Name");

            if (ModelState.IsValid)
            {
                var currentUser = this.User.Identity.GetUserId();
                if (input.BirthdayPerson == currentUser)
                {
                    throw new InvalidOperationException("It is allowed to start a new vote for the other people only!");
                }

                var voteExist = this.voteData.GetVote(input.BirthdayPerson, input.Year).FirstOrDefault();

                if (voteExist != null)
                {
                    //throw new InvalidOperationException("There is a vote for this user and year!");
                    return View("Error");
                }

                var birthdayPerson = this.birthdayData.GetUser(input.BirthdayPerson).FirstOrDefault();
                var initiator = this.birthdayData.GetUser(currentUser).FirstOrDefault();

                var vote = new Vote
                {
                    BirthdayPersonId = birthdayPerson.Id,
                    //BirthdayPerson = birthdayPerson,
                    InitiatorId=currentUser,
                    //Initiator = initiator,
                    StartDate = input.StartDate,
                    EndDate = input.EndDate,
                    Year = input.Year
                };

                this.dbData.Votes.Add(vote);
                this.dbData.Votes.SaveChanges();

                return this.RedirectToAction("OpenedVotes");
            }

            return View(input);
        }

        [HttpGet]
        [Authorize]
        public ActionResult OpenedVotes()
        {
            return View();
        }
    }
}