
namespace BirthdaySystem.Web.ViewModels.User
{
    using BirthdaySystem.Models;
    using BirthdaySystem.Web.Infrastructure.Mapping;

    public class UserSelectListModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}