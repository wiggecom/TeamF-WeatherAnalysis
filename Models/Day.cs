using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamF_WeatherAnalysis.Models
{
    internal class Day
    {
        public int YearInt { get; set; }
        public int MonthInt { get; set; }
        public int DayInt { get; set; }
        public double AvgTempIn { get; set; }
        public double AvgTempOut { get; set; }
        public int AvgMoistIn { get; set; }
        public int AvgMoistOut { get;set; }

    }
}
