using SimpleApi.Models;
using Microsoft.EntityFrameworkCore;

namespace SimpleApi.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly ApplicationDbContext dbContext;
        protected readonly DbSet<User> dbSet;

        public UserRepository(
            ApplicationDbContext dbContext
        )
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<User>();
        }

        public void Insert(in User user)
        {
            this.dbSet.Add(user);
            this.dbContext.SaveChanges();
        }

        public void Update(in User sender)
        {
            throw new System.NotImplementedException();
        }

        public int Save()
        {
            throw new System.NotImplementedException();
        }


        public System.Collections.Generic.IEnumerable<User> FindAll()
        {
            return this.dbSet.ToList();
        }

        public User FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IUserRepository : IRepository<User>
    {

    }
}
