using System;
using WorkStationLocker.ConsoleApp.Models;

namespace WorkStationLocker.ConsoleApp.Core
{
    public static class TimeManager
    {
        public static DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }

        public static string Stringify(this DateTime dateTime)
        {
            return dateTime.ToString(Constants.Time.DateFormat);
        }
    }
}
