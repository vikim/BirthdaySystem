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

        public IList<Present> GetAllPresents
        {
            get
            {
                var presents = this.Get<IList<Present>>("Presents",
                   () =>
                   {
                       return this.data.Presents.All()
                           .OrderBy(x => x.Name)
                           .ToList();
                   });

                return presents;
            }
        }
    }
}
