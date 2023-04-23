using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReminderApp.Models;

namespace ReminderApp.DAO
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _dbContext;

        public UserRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetUserByEmail(string email)
        {
            return _dbContext.Set<User>().Where(r => r.Email == email).ToList();
        }
    }
    public interface IUserRepository
    {
        List<User> GetUserByEmail(string email);
    }
}