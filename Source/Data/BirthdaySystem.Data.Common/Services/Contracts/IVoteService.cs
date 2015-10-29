namespace BirthdaySystem.Data.Common.Services.Contracts
{
    using System.Linq;

    using BirthdaySystem.Models;
    using BirthdaySystem.Data.Common.Data;

    using System.Collections.Generic;

    public interface IVoteService
    {
        IQueryable<Vote> GetVote(string birthdayPerson, int year);

        IQueryable<Vote> GetAvailableVotes(IBirthdayData dbData, string currentUser);
    }
}
