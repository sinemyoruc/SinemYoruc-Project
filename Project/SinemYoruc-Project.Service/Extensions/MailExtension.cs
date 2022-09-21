using Hangfire;
using SinemYoruc_Project.Data;
using SinemYoruc_Project.Hangfire;
using System;

namespace SinemYoruc_Project
{
    public class MailExtension
    {
        public void SendMessageMail(string email, string subject, string message)
        {
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 5, OnAttemptsExceeded = AttemptsExceededAction.Fail });
            Mail mail = new Mail();
            mail.Subject = subject;
            mail.ToEmail = email;
            mail.Body = message;
            BackgroundJob.Schedule(() => JobDelayed.SendEmailAsync(mail), TimeSpan.FromSeconds(2));

        }
        
        public void SendWelcomeMail(string email)
        {
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 5, OnAttemptsExceeded = AttemptsExceededAction.Fail });
            Mail mail = new Mail();
            mail.Subject = "Welcome";
            mail.ToEmail = email;
            mail.Body = "Welcome to app";
            BackgroundJob.Schedule(() => JobDelayed.SendEmailAsync(mail), TimeSpan.FromSeconds(2));
             
        }

        public void SendLoginMail(string email)
        {
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 5, OnAttemptsExceeded = AttemptsExceededAction.Fail });
            Mail mail = new Mail();
            mail.ToEmail = email;
            mail.Subject = "Login";
            mail.Body = "Login";
            BackgroundJob.Schedule(() => JobDelayed.SendEmailAsync(mail), TimeSpan.FromSeconds(2));

        }

        public void SendAcceptOfferMail()
        {
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 5, OnAttemptsExceeded = AttemptsExceededAction.Fail });
            Mail mail = new Mail();
            mail.Subject = "Offer";
            mail.ToEmail = "myrl.heller18@ethereal.email";
            mail.Body = "Your offer has been approved. You can buy the product";
            BackgroundJob.Schedule(() => JobDelayed.SendEmailAsync(mail), TimeSpan.FromSeconds(2));

        }

        public void SendRefuseOfferMail()
        {
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 5, OnAttemptsExceeded = AttemptsExceededAction.Fail });
            Mail mail = new Mail();
            mail.Subject = "Offer";
            mail.ToEmail = "myrl.heller18@ethereal.email";
            mail.Body = "Your offer has been refused :(";
            BackgroundJob.Schedule(() => JobDelayed.SendEmailAsync(mail), TimeSpan.FromSeconds(2));

        }

    }
}
