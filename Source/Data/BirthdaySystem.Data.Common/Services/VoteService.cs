namespace BirthdaySystem.Data.Common.Services
{
    using System.Linq;

    using BirthdaySystem.Data.Common.Repository;
    using BirthdaySystem.Data.Common.Services.Contracts;
    using BirthdaySystem.Models;
    using BirthdaySystem.Data.Common.Data;

    using System.Collections.Generic;

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


        public IQueryable<Vote> GetAvailableVotes(IBirthdayData dbData, string currentUser)
        {
            //var availableVotes = this.data.All()
            //    .Join(birthdayData.PresentsVotes.All(),
            //            v => v.Id,
            //            pv => pv.VoteId,
            //            (v, pv) => new { v, pv })
            //    //(v, pv) => new Vote
            //    //{
            //    //    VoteId = v.Id,
            //    //    BirthdayPerson = v.BirthdayPersonId,
            //    //    Initiator = v.InitiatorId,
            //    //    SytartDate = v.StartDate,
            //    //    EndDate = v.EndDate,
            //    //    UserId = pv.UserId
            //    //})
            //  .Where(av => av.v.EndDate == null &&
            //      av.v.BirthdayPersonId != currentUser &&
            //      av.pv.UserId != currentUser)
            //      .ToList();
            //      //.Select(av => new Vote
            //      //{
            //      //    Id = av.v.Id,
            //      //    InitiatorId = av.v.InitiatorId,
            //      //    Initiator = av.v.Initiator,
            //      //    BirthdayPersonId = av.v.BirthdayPersonId,
            //      //    BirthdayPerson = av.v.BirthdayPerson,
            //      //    StartDate = av.v.StartDate,
            //      //    EndDate = av.v.EndDate,
            //      //    Year = av.v.Year
            //      //});

            //var availableVotes = dbData.Votes.All()
            //       .Join(dbData.PresentsVotes.All().Where(pv => pv.UserId != currentUser),
            //             v => v.Id,
            //             pv => pv.VoteId,
            //             (v, pv) => v)
            //        .Where(av => av.EndDate == null && av.BirthdayPersonId != currentUser);

            var givenPresentVote = dbData.PresentsVotes.All()
                .Where(pv => pv.UserId == currentUser)
                .Select(pv => pv.VoteId)
                .ToArray();

            var availableVotes = this.data.All()
                .Where(v => (v.EndDate == null) &&
                            (v.BirthdayPerson.Id != currentUser) &&
                            (!givenPresentVote.Contains(v.Id)));

            return availableVotes;
        }
    }
}
