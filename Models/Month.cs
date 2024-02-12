using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamF_WeatherAnalysis.Models
{
    internal class Month
    {
        public int YearInt { get; set; }
        public int MonthInt { get; set; }
        public List<DayMeasure> Days { get; set; }
        public int AvgTemp { get; set; }
        public int AvgMoist { get; set; }
    }
}
