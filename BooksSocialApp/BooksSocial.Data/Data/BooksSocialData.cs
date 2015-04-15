namespace BooksSocial.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using BooksSocial.Data.Repositories;
    using BooksSocial.Models;

    public class BooksSocialData : IBooksSocialData
    {
        public DbContext context;

        private IDictionary<Type, object> repositories;

        public BooksSocialData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> User
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Author> Author
        {
            get { return this.GetRepository<Author>(); }
        }

        public IRepository<Book> Book
        {
            get { return this.GetRepository<Book>(); }
        }

        public IRepository<Genre> Genre
        {
            get { return this.GetRepository<Genre>(); }
        }

        public IRepository<Rating> Rating
        {
            get { return this.GetRepository<Rating>(); }
        }

        public IRepository<Review> Review
        {
            get { return this.GetRepository<Review>(); }
        }

        public IRepository<Shelf> Shelf
        {
            get { return this.GetRepository<Shelf>(); }
        }

        public IRepository<FriendRequest> FriendRequest
        {
            get { return this.GetRepository<FriendRequest>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);

                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
