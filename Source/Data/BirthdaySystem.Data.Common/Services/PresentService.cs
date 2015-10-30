namespace BirthdaySystem.Data.Common.Services
{
    using System.Linq;

    using BirthdaySystem.Data.Common.Repository;
    using BirthdaySystem.Data.Common.Services.Contracts;
    using BirthdaySystem.Models;

    public class PresentService : IPresentService
    {
        // /*
        private IRepository<Present> data;

        public PresentService(IRepository<Present> data)
        {
            this.data = data;
        }

        public IQueryable<Present> GetAllPresents()
        {
            var presents = this.data.All();

            return presents;
        }
        // * */
    }
}
