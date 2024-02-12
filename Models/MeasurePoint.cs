using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamF_WeatherAnalysis.Models
{
    internal class MeasurePoint
    {
        public int? YearInt { get; set; }
        public int? MonthInt { get; set; }
        public int? DayInt { get; set; }
        public int? HourInt { get; set; }
        public int? MinuteInt { get; set; }
        public int? SecondInt { get; set; }
        public string? InOut { get; set; }
        public double? Temp { get; set; }
        public int? Moist { get; set; }

        public MeasurePoint(int? yearInt, int? monthInt, int? dayInt, int? hourInt, int? minuteInt, int? secondInt, string? inOut, double? temp, int? moist)
        {
            YearInt = yearInt;
            MonthInt = monthInt;
            DayInt = dayInt;
            HourInt = hourInt;
            MinuteInt = minuteInt;
            SecondInt = secondInt;
            InOut = inOut;
            Temp = temp;
            Moist = moist;

        }
    }
}
