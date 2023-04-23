using System;
using System.Collections.Generic;
using System.Linq;
using ReminderApp.Models;
using ReminderApp.Models.Dto;
using ReminderApp.DAO;

namespace ReminderApp.Transactions
{
    public class ReminderService
    {
        private readonly UserUtils userUtils;
        private readonly ReminderRepository reminderRepository;

        public ReminderService(UserUtils userUtils, ReminderRepository reminderRepository)
        {
            this.userUtils = userUtils;
            this.reminderRepository = reminderRepository;
        }

        public void AddReminder(ReminderDto reminderDto)
        {
            Reminder reminder = new Reminder
            {
                Descriere = reminderDto.Descriere,
                Titlu = reminderDto.Title,
                Date = reminderDto.Date,
                User = userUtils.GetCurrentUser()
            };

            reminderRepository.Add(reminder);
            reminderRepository.SaveChanges();
        }

        public void DeleteReminder(List<int> ids)
        {
            var reminders = reminderRepository.GetByIds(ids);

            reminderRepository.RemoveRange(reminders);
            reminderRepository.SaveChanges();
        }

        public void UpdateReminder(ReminderDto reminderDto)
        {
            var reminder = reminderRepository.GetById(reminderDto.Id);

            if (reminder != null)
            {
                reminder.Titlu = reminderDto.Title;
                reminder.Descriere = reminderDto.Descriere;
                reminder.Date = reminderDto.Date;

                reminderRepository.SaveChanges();
            }
        }

        public List<ReminderDto> GetAllRemindersForUser(int id)
        {
            var reminders = reminderRepository.GetAllByUserId(id);

            return reminders.Select(reminder =>
                new ReminderDto(reminder.Id, reminder.Titlu, reminder.Descriere, reminder.Date)).ToList();
        }

        public List<ReminderDto> GetAllRemindersForUser(int id, DateTime date)
        {
            var reminders = reminderRepository.GetAllByUserId(id);

            return reminders.Where(reminder => reminder.Date.Date == date.Date)
                .Select(reminder => new ReminderDto(reminder.Id, reminder.Titlu, reminder.Descriere, reminder.Date)).ToList();
        }
    }
}