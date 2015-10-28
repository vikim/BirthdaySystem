namespace BirthdaySystem.Data.Common.Data
{
    using BirthdaySystem.Data.Common.Repository;
    using BirthdaySystem.Models;

    public interface IBirthdayData
    {
        IRepository<Vote> Votes { get; }

        IRepository<PresentVote> PresentsVotes { get; }

        IRepository<Present> Presents { get; }

        IRepository<ApplicationUser> Users { get; }
    }
}
