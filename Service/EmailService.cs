using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.NetworkInformation;

namespace OopsMyKeyboard.Service
{
    public class EmailService
    {
        private readonly Email _email;

        public EmailService(Email email)
        {
            _email = email;
        }

        public async void SendIfInternetIsAvailable(string text)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                var msg = new MailMessage();
                msg.From = new MailAddress(_email.email, _email.email);
                msg.To.Add(new MailAddress(_email.to));
                msg.Subject = DateTime.Now.ToShortDateString();
                msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Html));
                msg.Body = text;

                var smtpClient = new SmtpClient(_email.smpt, _email.port);
                var credentials = new NetworkCredential(_email.email, _email.password);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = credentials;
                smtpClient.EnableSsl = true;

                await smtpClient.SendMailAsync(msg);
                smtpClient.Dispose();
            }
        }
    }
}
