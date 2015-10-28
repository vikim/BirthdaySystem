namespace BirthdaySystem.Data.Common.Services.Contracts
{
    using System.Linq;

    using BirthdaySystem.Models;

    public interface IVoteService
    {
        IQueryable<Vote> GetVote(string birthdayPerson, int year);
    }
}
