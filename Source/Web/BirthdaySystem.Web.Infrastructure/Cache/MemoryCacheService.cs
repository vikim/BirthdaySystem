namespace BirthdaySystem.Web.Infrastructure.Cache
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.WebPages.Html;

    using BirthdaySystem.Data.Common.Data;
    using BirthdaySystem.Models;
    using System.Collections;

    public class MemoryCacheService : BaseCacheService, ICacheService
    {
        private readonly IBirthdayData data;

        public MemoryCacheService(IBirthdayData data)
        {
            this.data = data;
        }

        /*
        public IList<ApplicationUser> BirthdayPeople
        {
            get
            {
                var birthdayPeople = this.Get<IList<ApplicationUser>>("BirthdayPeople",
                   () =>
                   {
                       return this.data.Users.All()
                           .OrderBy(x => x.FirstName)
                           .ThenBy(x => x.LastName)
                           //.Select(x => new UserSelectListModel { Id = x.Id, Name = x.Name })
                           .ToList();
                   });

                return birthdayPeople;
            }
        }
         * */
    }
}
