namespace BirthdaySystem.Web.Infrastructure.Cache
{
    using System.Collections.Generic;
    using System.Web.WebPages.Html;

    using BirthdaySystem.Models;

    public interface ICacheService
    {
        IList<Present> GetAllPresents { get; }
    }
}
