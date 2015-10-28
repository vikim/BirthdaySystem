namespace BirthdaySystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using BirthdaySystem.Data.Common.Data;
    using BirthdaySystem.Web.ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly IBirthdayData data;


        public HomeController(IBirthdayData data)
        {
            this.data = data;
        }

        public ActionResult Index()
        {
            //var votes = this.votes.All(); //.Project().To<IndexBlogPostViewModel>();
            ///*
            var indexVoteModel = this.data.Votes.All()
                .Where(v => v.StartDate < DateTime.Now && v.EndDate != null)
                //.ProjectTo<VoteModel>()
                .Project()
                .To<VoteModel>()
                .ToList();


            return View(indexVoteModel);
            // */

           // return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}