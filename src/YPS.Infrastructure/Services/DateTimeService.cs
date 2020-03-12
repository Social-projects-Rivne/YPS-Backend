using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;

namespace YPS.Infrastructure.Services
{
    public class DateTimeService : IDateTimeSevice
    {
        public DateTime GetFirstDayOfWeek()
        {
            DateTime dt = DateTime.Now;
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            int difference = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;

            if (difference < 0)
                difference += 7;

            return dt.AddDays(-difference).Date;
        }
    }
}
