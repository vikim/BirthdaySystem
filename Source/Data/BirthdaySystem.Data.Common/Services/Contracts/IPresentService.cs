namespace BirthdaySystem.Data.Common.Services.Contracts
{
    using System.Linq;

    using BirthdaySystem.Models;

    public interface IPresentService
    {
        IQueryable<Present> GetAllPresents();
    }
}
