using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReminderApp.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Parola { get; set; }

        public User() { }

        public User(int id, string email, string firstName, string lastName, string parola)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Parola = parola;
        }
    }
}