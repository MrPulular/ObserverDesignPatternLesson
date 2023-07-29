using MediatR;
using System.Net.Mail;
using System.Net;
using WebApp.Observer.Events;
using WebApp.Observer.Observer;

namespace WebApp.Observer.EventHandlers
{
    public class SendEmailEventHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly ILogger<SendEmailEventHandler> _logger;

        public SendEmailEventHandler(ILogger<SendEmailEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            

            var mailMessage = new MailMessage();
            var smptClient = new SmtpClient("**********");
            mailMessage.From = new MailAddress("**************");
            mailMessage.To.Add(new MailAddress(notification.AppUser.Email));
            mailMessage.Subject = "Sitemize hoş geldiniz";
            mailMessage.Body = "<p>Sitemizin Genel Kuralları : ...</p>";
            mailMessage.IsBodyHtml = true;
            smptClient.Port = 587;
            smptClient.Credentials = new NetworkCredential("*************", "*************");
            smptClient.Send(mailMessage);
            _logger.LogInformation($"Email was send to user :{notification.AppUser.UserName}");

            return Task.CompletedTask;
        }
    }
}
