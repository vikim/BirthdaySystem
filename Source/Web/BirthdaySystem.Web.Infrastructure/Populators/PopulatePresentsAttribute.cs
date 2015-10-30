namespace BirthdaySystem.Web.Infrastructure.Populators
{
    using System.Web.Mvc;
       
    using Ninject;

    using BirthdaySystem.Web.Infrastructure.Cache;
    
    public class PopulatePresentsAttribute : ActionFilterAttribute
    {
        [Inject]
        public ICacheService Cache { private get; set; }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.PresentsId = new SelectList(Cache.GetAllPresents, "Id", "Name");
            base.OnResultExecuting(filterContext);
        }
    }
}
