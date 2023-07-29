using BaseProject.Models;
using System.Net;
using System.Net.Mail;

namespace WebApp.Observer.Observer
{
    public class UserObserverSendEmail : IUserObserver
    {
        private readonly IServiceProvider _serverProvider;

        public UserObserverSendEmail(IServiceProvider serverProvider)
        {
            _serverProvider = serverProvider;
        }

        public void UserCreated(AppUser appUser)
        {
            var logger = _serverProvider.GetRequiredService<ILogger<UserObserverSendEmail>>();

            var mailMessage = new MailMessage();
            var smptClient = new SmtpClient("********");
            mailMessage.From = new MailAddress("**************");
            mailMessage.To.Add(new MailAddress(appUser.Email));
            mailMessage.Subject = "Sitemize hoş geldiniz";
            mailMessage.Body = "<p>Sitemizin Genel Kuralları : ...</p>";
            mailMessage.IsBodyHtml = true;
            smptClient.Port = 587;
            smptClient.Credentials = new NetworkCredential("**************","***************");
            smptClient.Send(mailMessage);
            logger.LogInformation($"Email was send to user :{appUser.UserName}");
        }
    }
}
