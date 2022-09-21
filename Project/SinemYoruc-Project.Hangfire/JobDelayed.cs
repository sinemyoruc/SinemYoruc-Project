using SinemYoruc_Project.Data;
using System.Net.Mail;

namespace SinemYoruc_Project.Hangfire
{
    public class JobDelayed
    {
        public static async Task SendEmailAsync(Mail dto)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.ethereal.email", 587);
            mail.From = new MailAddress("gertrude.daniel25@ethereal.email", "Sender");
            mail.To.Add(dto.ToEmail);
            mail.Subject = dto.Subject;
            mail.Body = dto.Body;
            mail.IsBodyHtml = true;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("gertrude.daniel25@ethereal.email", "YWZBpZHrGnwh95gcTN");
            SmtpServer.EnableSsl = false;
            await Task.Run(() =>
            {
                SmtpServer.SendAsync(mail, null);
            });
        }

    }
}
