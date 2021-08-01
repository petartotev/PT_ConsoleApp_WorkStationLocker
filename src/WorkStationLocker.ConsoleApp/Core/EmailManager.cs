using OpenPop.Mime;
using OpenPop.Pop3;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using WorkStationLocker.ConsoleApp.Models;

namespace WorkStationLocker.ConsoleApp.Core
{
    public static class EmailManager
    {
        public static string GetLastEmailHeaderFromInbox()
        {
            try
            {
                Console.InputEncoding = Console.OutputEncoding = Encoding.Unicode;

                var client = new Pop3Client();
                client.Connect("pop.gmail.com", 995, true);
                client.Authenticate(Credentials.Address, Credentials.Password);

                var count = client.GetMessageCount();
                Message message = client.GetMessage(count);
                return message.Headers.Subject;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Error: " + ex.Message;
            }
        }

        public static bool SendEmail()
        {
            #region CommentsOnSmtpClient
            // MailAddress fromAddress/string fromPassword - email/password in Gmail to get access to the SmtpClient Host ("smpt.gmail.com").
            // That would throw a SmtpException: 5.7.0 Authentication Required.
            // You would also receive an email in Gmail saying "Critical security alert".
            // What you need to do is to press "Check Activity" => Less secure app blocked => Learn more => Less secure app access => Allow less secure apps: ON.
            // Now it should work.
            #endregion

            MailAddress fromAddress = new MailAddress(Credentials.Address);
            string fromPassword = Credentials.Password;
            // Send to myself...
            var toAddress = new MailAddress(Credentials.Address);

            string currTime = "Lock" + TimeManager.GetCurrentDateTime().Stringify();
            string subject = currTime;
            string body = currTime;

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            try
            {
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                    return true;
                }
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
