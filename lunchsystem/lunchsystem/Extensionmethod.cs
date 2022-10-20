using System;
using System.Globalization;

namespace lunchsystem
{
    public static class DateTimeExtension
    {
        // TODO 20221017：年 - 三位數、月 - 兩位數、日 - 兩位數 !done
        public static string toTWDate(this DateTime datetime)
        {
            TaiwanCalendar taiwanCalendar = new TaiwanCalendar();

            string year = taiwanCalendar.GetYear(datetime).ToString();
            string month = datetime.Month.ToString();
            string day = datetime.Day.ToString();

            return
                string.Format("{0}/{1}/{2}", 
                year.PadLeft(3,'0'),
                month.PadLeft(2,'0'), 
                day.PadLeft(2,'0'));

        }
    }
}
