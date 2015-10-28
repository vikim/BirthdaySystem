namespace BirthdaySystem.Data.Common.Services
{
    using System.Linq;

    using BirthdaySystem.Data.Common.Repository;
    using BirthdaySystem.Data.Common.Services.Contracts;
    using BirthdaySystem.Models;

    public class VoteService : IVoteService
    {
        private IRepository<Vote> data;

        public VoteService(IRepository<Vote> data)
        {
            this.data = data;
        }
        public IQueryable<Vote> GetVote(string birthdayPerson, int year)
        {
            var vote = this.data.All()
                .Where(x => x.BirthdayPersonId == birthdayPerson && x.Year == year);

            return vote;
        }
    }
}
