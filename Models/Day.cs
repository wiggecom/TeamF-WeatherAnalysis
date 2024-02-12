using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamF_WeatherAnalysis.Models
{
    internal class DayMeasure
    {
        public int YearInt { get; set; }
        public int MonthInt { get; set; }
        public int DayInt { get; set; }
        public double AvgTempIn { get; set; }
        public double AvgTempOut { get; set; }
        public int AvgMoistIn { get; set; }
        public int AvgMoistOut { get;set; }
        public double MoldRisk { get; set; }

        public DayMeasure(int yearInt, int monthInt, int dayInt, double avgTempIn, double avgTempOut, int avgMoistIn, int avgMoistOut)
        {
            YearInt = yearInt;
            MonthInt = monthInt;
            DayInt = dayInt;
            AvgTempIn = avgTempIn;
            AvgTempOut = avgTempOut;
            AvgMoistIn = avgMoistIn;
            AvgMoistOut = avgMoistOut;
        }
        public DayMeasure(int yearInt, int monthInt, int dayInt, double avgTempIn, double avgTempOut, int avgMoistIn, int avgMoistOut, double moldRisk)
        {
            YearInt = yearInt;
            MonthInt = monthInt;
            DayInt = dayInt;
            AvgTempIn = avgTempIn;
            AvgTempOut = avgTempOut;
            AvgMoistIn = avgMoistIn;
            AvgMoistOut = avgMoistOut;
            MoldRisk = moldRisk;
        }
    }
}
