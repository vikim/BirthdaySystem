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
    using BirthdaySystem.Web.ViewModels.Home;

    public class VoteController : Controller
    {
        private IBirthdayPeopleService birthdayData;
        private IVoteService voteData;
        private IPresentService presentData;
        private readonly IBirthdayData dbData;

        public VoteController(IBirthdayPeopleService birthdayPeople, IVoteService voteData, IPresentService presentData, IBirthdayData dbData)
        {
            this.birthdayData = birthdayPeople;
            this.voteData = voteData;
            this.presentData = presentData;
            this.dbData = dbData;
        }

        [HttpGet]
        [Authorize]
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
                    InitiatorId = currentUser,
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
            var availableVotes = this.voteData
                .GetAvailableVotes(this.dbData, this.User.Identity.GetUserId())
                .ProjectTo<VoteModel>()
                .ToList();

            return View(availableVotes);
        }

        [HttpGet]
        [Authorize]
        [PopulatePresents]
        public ActionResult PresentVote(int id, string birthdayPersonName)
        {
            var presentVateModel = new PresentVoteModel
            {
                VoteId = id,
                BirthdayPerson = birthdayPersonName,
            };

            return View(presentVateModel);
        }


        [HttpPost]
        [Authorize]
        [PopulatePresents]
        [ValidateAntiForgeryToken]
        // http://www.codeproject.com/Articles/758458/Passing-Data-View-to-Controller-Controller-to-View
        // TODO : Do dripdown list with cashed data from ViewBag!!!
        public ActionResult PresentVote(PresentVoteModel input, FormCollection formCollection)
        {
            //formCollection.Get("YearTo")
            if (!string.IsNullOrEmpty(formCollection.Get("PresentsId")))
            {
                var presentVote = new PresentVote
                {
                    VoteId = input.VoteId,
                    UserId = this.User.Identity.GetUserId(),
                    PresentId = int.Parse(formCollection.Get("PresentsId")),
                    DateVote = DateTime.Now
                };

                this.dbData.PresentsVotes.Add(presentVote);
                this.dbData.Votes.SaveChanges();

                return this.RedirectToAction("OpenedVotes");
            }
            
            return View(input);
        }


        /*
         * 
        [HttpGet]
        [Authorize]
        [PopulatePresents]
        public ActionResult PresentVote(int id, string birthdayPersonName)
        {
            //var model = new PresentVoteModel();
            var presentVateModel = new PresentVoteModel
            {
                VoteId = id,
                // UserId = this.User.Identity.GetUserId(),
                BirthdayPerson = birthdayPersonName,
                // DateVote = DateTime.Now,
            };

            var presents = this.presentData.GetAllPresents().ToList();

            presentVateModel.Presents = new SelectList(presents, "Id", "Name"); ;

            return View(presentVateModel);
        }
         * 
         * 
         * 
        [HttpPost]
        [Authorize]
        [PopulatePresents]
        [ValidateAntiForgeryToken]
        // http://www.codeproject.com/Articles/758458/Passing-Data-View-to-Controller-Controller-to-View
        // TODO : Do dripdown list with cashed data from ViewBag!!!
        public ActionResult PresentVote(PresentVoteModel input) // , FormCollection presentsDropdown) //
        {
            var presents = this.presentData.GetAllPresents().ToList();

            input.Presents = new SelectList(presents, "Id", "Name"); ;

            if (ModelState.IsValid)
            {
                var presentVote = new PresentVote
                {
                    VoteId = input.VoteId,
                    UserId = this.User.Identity.GetUserId(),
                    PresentId = input.PresentId, //int.Parse(input.Present),
                    DateVote = DateTime.Now
                };

                this.dbData.PresentsVotes.Add(presentVote);
                this.dbData.Votes.SaveChanges();

                return this.RedirectToAction("OpenedVotes");
            }

            return View(input);
        }
        */
            

        //[HttpGet]
        [Authorize]
        public ActionResult CloseVote()
        {
            var votesForClosingByTheUser = this.voteData
                .GetAllUnclosedVotes(this.User.Identity.GetUserId())
                .Project()
                .To<VoteModel>()
                .ToList();

            return View(votesForClosingByTheUser);
        }

        //[HttpPost]
        [Authorize]
        public ActionResult CloseVoteById(int id)
        {
            this.voteData.CloseVote(id);

            //var votesForClosingByTheUser = this.voteData
            //    .GetAllUnclosedVotes(this.User.Identity.GetUserId())
            //    .Project()
            //    .To<VoteModel>()
            //    .ToList();

            //return View(votesForClosingByTheUser);

            return this.RedirectToAction("CloseVote");
        }
    }
}