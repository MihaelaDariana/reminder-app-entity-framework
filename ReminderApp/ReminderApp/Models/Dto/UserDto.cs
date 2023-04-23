namespace ReminderApp.Models.Dto
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }

        public UserDto() { }

        public UserDto(string firstName, string lastName, string email, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Id = id;
        }
    }
}