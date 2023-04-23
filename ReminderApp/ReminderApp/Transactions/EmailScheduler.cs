using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReminderApp.Models.Dto;

namespace ReminderApp.Transactions
{
    public class EmailScheduler
    {
        private readonly EmailService emailService;
        private readonly UserService userService;
        private readonly ReminderService reminderService;

        public EmailScheduler(EmailService emailService, UserService userService, ReminderService reminderService)
        {
            this.emailService = emailService;
            this.userService = userService;
            this.reminderService = reminderService;
        }

        public async Task ScheduleEmail()
        {
            var currentDate = DateTime.Now;
            var userDto = await userService.FindUsers().ToListAsync();
            foreach (var userDto1 in userDto)
            {
                var reminderDtos = await reminderService.GetAllRemindersForUser(userDto1.Id, currentDate).ToListAsync();
                var remindersTitle = "";
                foreach (var reminderDto1 in reminderDtos)
                {
                    remindersTitle = remindersTitle + "\n" + reminderDto1.Title;
                }
                if (reminderDtos.Any())
                {
                    await emailService.SendEmail(userDto1.Email, "The reminders for today",
                        " Make sure that you check the remindares that you have today! :)" + remindersTitle);
                }
            }

        }
    }
}