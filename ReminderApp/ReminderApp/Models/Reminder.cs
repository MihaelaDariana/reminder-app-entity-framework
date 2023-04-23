using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReminderApp.Models
{
    [Table("Reminder")]
    public class Reminder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Titlu { get; set; }

        public string Descriere { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public Reminder() { }

        public Reminder(int id, string titlu, string descriere, DateTime date, User user)
        {
            Id = id;
            Titlu = titlu;
            Descriere = descriere;
            Date = date;
            User = user;
            UserId = user.Id;
        }
    }
}