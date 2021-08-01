using System;
using System.Text.RegularExpressions;
using System.Threading;
using WorkStationLocker.ConsoleApp.Core;
using WorkStationLocker.ConsoleApp.Models;

namespace WorkStationLocker.ConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine($"If an email with header like 'Lock {Constants.Time.DateFormat}' was received in the last {Constants.Time.DelaySeconds} seconds\n" +
                "the WorkStation would be locked...\n");

            // EmailManager.SendEmail();

            while (true)
            {
                var timeCurr = TimeManager.GetCurrentDateTime();

                try
                {
                    var emailMessageHeader = EmailManager.GetLastEmailHeaderFromInbox();

                    if (Regex.IsMatch(emailMessageHeader, @"^Lock[0-9]{12}\b"))
                    {
                        DateTime timeEmail = DateTime.ParseExact(emailMessageHeader.Replace("Lock", ""), Constants.Time.DateFormat, null);

                        if ((timeCurr - timeEmail <= TimeSpan.FromSeconds(Constants.Time.DelaySeconds)) && 
                            (timeCurr - timeEmail >= TimeSpan.FromSeconds(0)))
                        {
                            Console.WriteLine($"Locked in {TimeManager.GetCurrentDateTime()}.");
                            CommandManager.LockWorkStation();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Thread.Sleep(Constants.Time.DelaySeconds * 1000 /*ms*/);
            }
        }
    }
}
