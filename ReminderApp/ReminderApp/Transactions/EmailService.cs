using System.Net;
using System.Net.Mail;

namespace ReminderApp.Transactions
{
    public class EmailService
    {
        private SmtpClient client;
        private string username;
        private string password;
        private string fromEmail;

        public EmailService()
        {
            this.username = "76e18680191203";
            this.password = "760bf7792fa95c";
            this.fromEmail = "diana.david.qwerty@gmail.com";

            client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };
        }

        public void SendEmail(string toEmail, string subject, string body)
        {
            MailMessage message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body
            };

            client.Send(message);
        }
    }
}