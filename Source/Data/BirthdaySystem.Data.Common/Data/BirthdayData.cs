namespace BirthdaySystem.Data.Common.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using BirthdaySystem.Data;
    using BirthdaySystem.Data.Common.Repository;
    using BirthdaySystem.Models;

    public class BirthdayData : IBirthdayData
    {
        private ApplicationDbContext context;

        private IDictionary<Type, object> dict = new Dictionary<Type, object>();

        public BirthdayData(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IRepository<Vote> Votes
        {
            get
            {
                return this.GetRepository<Vote>();
            }
        }

        public IRepository<PresentVote> PresentsVotes
        {
            get
            {
                return this.GetRepository<PresentVote>();
            }
        }

        public IRepository<Present> Presents
        {
            get
            {
                return this.GetRepository<Present>();
            }
        }

        /*
        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }*/

        private IRepository<T> GetRepository<T>()
           where T : class
        {
            var type = typeof(T);

            if (!dict.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<T>);

                /*
                if (type.IsAssignableFrom(typeof(ApplicationUser)))
                {
                    repositoryType = typeof(GenericRepository);
                    //var userRepository = this.context.Set<User>();
                }
                */

                var instance = Activator.CreateInstance(repositoryType, this.context);
                //var instance = Activator.CreateInstance(repositoryType, this.context.Set<User>());

                dict.Add(type, instance);
            }

            return (IRepository<T>)dict[type];
        }
    }
}
