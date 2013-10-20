using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using Future3.Models;

namespace Future3.Services
{
    public class TimeMachineService
    {
        public static readonly IList<EmailSendModel> Requests =
            new List<EmailSendModel>();

        public void Run()
        {
            while (true)
            {
                SingleRun();
                Thread.Sleep(1000);
            }
        }

        public void SingleRun()
        {
            var emailsToSend = Requests.Where(x => x.Date < DateTime.Now);
            foreach (var emailModel in emailsToSend)
            {
                var smtpClient = new SmtpClient("localhost");
                smtpClient.Send("mvc4@future3.com", emailModel.Email, "Future Machine message", emailModel.Content);
            }
        }
    }
}