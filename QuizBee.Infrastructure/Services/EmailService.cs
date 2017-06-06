using Microsoft.AspNet.Identity;
using System;
using System.Net;
using System.Net.Mail;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Web;
using System.Threading.Tasks;

namespace QuizBee.Infrastructure.Services
{
    public class EmailService : IIdentityMessageService
    {
        public object ConfigurationManager { get; private set; }

        public async Task SendAsync(IdentityMessage message)
        {
            await configSendGridasync(message);
        }

        // Use NuGet to install SendGrid (Basic C# client lib) 
        private async Task configSendGridasync(IdentityMessage message)
        {
            var myMessage = new SendGrid.SendGridMessage();

            myMessage.AddTo(message.Destination);
            myMessage.From = new System.Net.Mail.MailAddress("gvb4676@gmail.com", "QuizBee Admin");
            myMessage.Subject = message.Subject;
            myMessage.Text = message.Body;
            myMessage.Html = message.Body;

            var credentials = new NetworkCredential("gvb4676@gmail.com", "Gvb@Admin");


            // Create a Web transport for sending email.
            var transportWeb = new Web(credentials);

            // Send the email.
            if (transportWeb != null)
            {
                await transportWeb.DeliverAsync(myMessage);
            }
            else
            {
                //Trace.TraceError("Failed to create Web transport.");
                await Task.FromResult(0);
            }
        }
    }
}
