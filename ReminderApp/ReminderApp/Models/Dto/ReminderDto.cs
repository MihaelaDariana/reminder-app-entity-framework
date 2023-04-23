using System;

namespace ReminderApp.Models.Dto
{
    public class ReminderDto
    {
        public string Title { get; set; }
        public string Descriere { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }

        public ReminderDto(int id, string title, string descriere, DateTime date)
        {
            Id = id;
            Title = title;
            Descriere = descriere;
            Date = date;
        }

        public int GetId()
        {
            return Id;
        }

        public string GetTitle()
        {
            return Title;
        }

        public string GetDescriere()
        {
            return Descriere;
        }

        public DateTime GetDate()
        {
            return Date;
        }
    }
}