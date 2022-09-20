using SinemYoruc_Project.Dto;
using System;
using System.Net.Mail;

namespace SinemYoruc_Project.Hangfire
{
    public class JobDelayed
    {
        public static async Task SendEmailAsync(MailDto dto)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
            mail.From = new MailAddress("emptymail610@gmail.com", "Gönderen");
            mail.To.Add(dto.ToEmail);
            mail.Subject = dto.Subject;
            mail.Body = dto.Body;
            mail.IsBodyHtml = true;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("emptymail610@gmail.com", "empty-mail-610-S");
            SmtpServer.EnableSsl = true;

            await Task.Run(() =>
            {
                SmtpServer.SendAsync(mail, null);
            });
        }

    }
}
