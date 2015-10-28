namespace BirthdaySystem.Web.Infrastructure.Populators
{
    using System.Web.Mvc;
       
    using Ninject;

    using BirthdaySystem.Web.Infrastructure.Cache;
    
    public class PopulateBirthdayPeopleAttribute : ActionFilterAttribute
    {
        /*
        [Inject]
        public ICacheService Cache { private get; set; }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.BirthdayPeopleId = new SelectList(Cache.BirthdayPeople, "Id", "Name");
            base.OnResultExecuting(filterContext);
        }
         * */
    }
}
