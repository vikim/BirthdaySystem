namespace BirthdaySystem.Data.Common.Services.Contracts
{
    using System.Linq;

    using BirthdaySystem.Models;

    public interface IBirthdayPeopleService
    {
        IQueryable<ApplicationUser> GetAllBirthdayPeople(string user);

        IQueryable<ApplicationUser> GetUser(string userId);
    }
}
