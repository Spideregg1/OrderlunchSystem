using System;
using System.Globalization;

namespace lunchsystem
{
    public static class DateTimeExtension
    {
        public static string TWDate(this DateTime datetime)
        {
            TaiwanCalendar taiwanCalendar = new TaiwanCalendar();
            return taiwanCalendar.GetYear(datetime).ToString() + "/" + datetime.Month.ToString() + "/" + datetime.Day.ToString();
        }
    }
}
