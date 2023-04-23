using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReminderApp.Models;
using ReminderApp.Models.Dto;

namespace ReminderApp.DAO
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly DbContext dbContext;

        public ReminderRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Reminder> GetAllByUserId(int userId)
        {
            return dbContext.Set<Reminder>().Where(r => r.UserId == userId).ToList();
        }

        public void Add(Reminder reminder)
        {   // sa revenim .Reminder
            dbContext.Add(reminder);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public IEnumerable<Reminder> GetByIds(IEnumerable<int> ids)
        {
            return dbContext.Set<Reminder>().Where(r => ids.Contains(r.Id)).ToList();
        }
        public Reminder GetById(int id)
        {
            var reminderById = dbContext.Set<Reminder>().Where(r => r.Id == id).ToList();
            return reminderById[0];
        }
        public void RemoveRange(IEnumerable<Reminder> reminders)
        {
            dbContext.RemoveRange();
        }


    }

    public interface IReminderRepository
    {
        List<Reminder> GetAllByUserId(int userId);
    }
}