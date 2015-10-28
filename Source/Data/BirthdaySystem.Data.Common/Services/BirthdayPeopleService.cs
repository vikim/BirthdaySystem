namespace BirthdaySystem.Data.Common.Services
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using BirthdaySystem.Data.Common.Repository;
    using BirthdaySystem.Data.Common.Services.Contracts;
    using BirthdaySystem.Models;

    public class BirthdayPeopleService : IBirthdayPeopleService
    {
        private IRepository<ApplicationUser> data;

        public BirthdayPeopleService(IRepository<ApplicationUser> data)
        {
            this.data = data;
        }

        public IQueryable<ApplicationUser> GetAllBirthdayPeople(string user)
        {
            var birthdayPeople = this.data.All()
                .Where(p => p.Id != user);
            //.Select(p => { Id = p.Id, Name = p.Name });

            return birthdayPeople;
        }


        public IQueryable<ApplicationUser> GetUser(string userId)
        {
            var user = this.data.All()
                .Where(x => x.Id == userId);

            return user;
        }
    }
}
