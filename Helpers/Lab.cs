using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TeamF_WeatherAnalysis.Models;

namespace TeamF_WeatherAnalysis.Helpers
{
    internal class Lab
    {
        public static List<MeasurePoint> ReadAll(List<MeasurePoint> measurePoints)
        {
            List<string> list = new List<string>();
            list = ReadAll2(list).ToList();
            string listString = string.Join(Environment.NewLine, list);

            foreach (Match m in Test2(listString, Patterns.matchAll))
            {
                int yearInt = 0;
                int monthInt = 0;
                int dayInt = 0;
                int hourInt = 0;
                int minuteInt = 0;
                int secondInt = 0;
                string inOut = "";
                double temp = 0.0;
                int moist = 0;
                foreach (Group group in m.Groups)
                {
                    switch (group.Name)
                    {
                        case "year":
                            yearInt = int.Parse(group.Value);
                            break;
                        case "month":
                            monthInt = int.Parse(group.Value);
                            break;
                        case "day":
                            dayInt = int.Parse(group.Value);
                            break;
                        case "hour":
                            hourInt = int.Parse(group.Value);
                            break;
                        case "minute":
                            minuteInt = int.Parse(group.Value);
                            break;
                        case "second":
                            secondInt = int.Parse(group.Value);
                            break;
                        case "indoor":
                            inOut = group.Value;
                            break;
                        case "temp":
                            temp = double.Parse(group.Value, CultureInfo.InvariantCulture);
                            break;
                        case "moist":
                            moist = int.Parse(group.Value);
                            break;
                    }
                }
                measurePoints.Add(new MeasurePoint(yearInt, monthInt, dayInt, hourInt, minuteInt, secondInt, inOut, temp, moist));
            }
            //AverageDay(measurePoints, dayList, 11, 7);   // Call specific date
            return measurePoints;
        }
        public static List<DayMeasure> GetAllAverages(List<DayMeasure> dayList, List<MeasurePoint> measurePoints)
        {
            Console.SetCursorPosition(Statics.listPosX, 11);
            Console.WriteLine("Loading...");
            dayList = AllDays(measurePoints, dayList);
            Console.SetCursorPosition(Statics.listPosX, 11);
            Console.WriteLine("Loading Complete");
            for (int i = 0; i < 35; i++)
            {
                MoveListBuffer();
                Thread.Sleep(20);
            }
            Thread.Sleep(500);
            Console.BackgroundColor = (ConsoleColor)Statics.bgPlotColor;
            //Console.Clear();
            Gfx.InitGfx();
            return dayList;
        }
        public static List<DayMeasure> AllDays(List<MeasurePoint> measurePoints, List<DayMeasure> dayList)
        {

            for (int monthInt = 6; monthInt <= 12; monthInt++)
            {
                for (int dayInt = 1; dayInt <= 31; dayInt++)
                {
                    dayList = AverageToList(measurePoints, dayList, monthInt, dayInt);
                }
            }
            return dayList;
        }
        public static void SortedList(List<DayMeasure> dayList)
        {
            List<DayMeasure> byTemperature = new List<DayMeasure>();
            byTemperature = dayList.OrderBy(o => o.YearInt).ThenBy(o => o.MonthInt).ThenBy(o => o.AvgTempOut).ToList();
            byTemperature.Reverse();
            int i = 6;
            foreach (DayMeasure d in byTemperature)
            {

                SetCursorPosList();
                Console.Write("Month - " + i);
                MoveListBuffer();
                foreach (DayMeasure d2 in byTemperature.Where(m => m.MonthInt == i))
                {
                    Gfx.SetLeftColor();
                    SetCursorPosList();
                    Console.Write("temp: " + d2.AvgTempOut);
                    MoveListBuffer();
                    PlotBlock((int)d2.AvgTempOut, Statics.tempOut, 0, 10, 17);

                }
                i++;
                Gfx.SetLeftColor();
                SetCursorPosList();
                MoveListBuffer();
                if (i < 12)
                {
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                }
                else if (i >= 13) { break; }
            }
        }
        public static void SortedMoldOut(List<DayMeasure> dayList)
        {
            List<DayMeasure> byMoldRisk = new List<DayMeasure>();
            //byTemperature.Reverse();
            int i = 6;
            double temp = 0;
            double moist = 0;
            foreach (DayMeasure d in dayList)
            {

                SetCursorPosList();
                Console.Write("Month - " + i);
                MoveListBuffer();
                foreach (DayMeasure dx in dayList.Where(m => m.MonthInt == i))
                {
                    temp = dx.AvgTempOut;
                    moist = dx.AvgMoistOut;
                    double moldRisk = TextAnalyser.MoldRiskCalc(temp, moist);
                    moldRisk = Math.Round(moldRisk, 2, MidpointRounding.AwayFromZero);
                    if (moldRisk < 0)
                    {
                        moldRisk = 0;
                    }
                    Gfx.SetLeftColor();
                    SetCursorPosList();
                    Console.Write("Risk for mold on " + dx.YearInt + "-" + dx.MonthInt + "-" + dx.DayInt + " is " + moldRisk + "%");
                    MoveListBuffer();
                    PlotBlock((int)moldRisk, Statics.moldRisk, 25, 50, 75);
                    if (moldRisk > 0)
                    {
                        dx.MoldRisk = moldRisk;
                        byMoldRisk.Add(dx);
                    }
                }
                i++;
                Gfx.SetLeftColor();
                SetCursorPosList();
                MoveListBuffer();
                if (i < 12)
                {
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                }
                else if (i >= 13) { break; }
            }
            int writeFile = 0;
            Gfx.SetLeftColor();
            SetCursorPosList();
            Console.Write("Do you wish to export to file? Y/N");

            var userInputKey = Console.ReadKey(true);
            if (userInputKey.Key == ConsoleKey.Y)
            {
                Gfx.InitGfxSwitch();
                writeFile = 1;
            }
            if (userInputKey.Key == ConsoleKey.N)
            {
                Gfx.InitGfxSwitch();
                writeFile = 0;
            }
            MoveListBuffer();
            byMoldRisk = byMoldRisk.OrderByDescending(o => o.MoldRisk).ToList();
            double recordedRisk = 0;
            string dayStr = "";
            string monthStr = "";
            if (writeFile == 1)
            {
                using (StreamWriter writer = new StreamWriter(Statics.path + Statics.fileMoldRisk, false)) // false - do not append
                {
                    foreach (DayMeasure m in byMoldRisk)
                    {
                        dayStr = m.DayInt.ToString();
                        monthStr = m.MonthInt.ToString();
                        if (dayStr.Length == 1) { dayStr = "0" + dayStr; }
                        if (monthStr.Length == 1) { monthStr = "0" + monthStr; }
                        writer.WriteLine("Risk for mold on " + m.YearInt + "-" + monthStr + "-" + dayStr + " - " + m.MoldRisk + " %");
                    }
                }

            }
            foreach (DayMeasure m in byMoldRisk)
            {
                Gfx.SetLeftColor();
                SetCursorPosList();
                dayStr = m.DayInt.ToString();
                monthStr = m.MonthInt.ToString();
                if (dayStr.Length == 1) { dayStr = "0" + dayStr; }
                if (monthStr.Length == 1) { monthStr = "0" + monthStr; }
                Console.Write("Risk for mold on " + m.YearInt + "-" + monthStr + "-" + dayStr + " - " + m.MoldRisk + " %");
                MoveListBuffer();
                PlotBlock((int)m.MoldRisk, Statics.moldRisk, 25, 50, 75);
            }
            MoveListBuffer();
            SetCursorPosList();
        }
        public static void CheckFall(List<DayMeasure> dayList)
        {
            List<DayMeasure> coldDays = dayList.Where(a => a.AvgTempOut <= 10).ToList(); // grab all cold days to a list
            List<DayMeasure> giveMeFive = new List<DayMeasure>();
            string[] monthNames = { "January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December", };
            int counter = 0;
            int maxLoop = 1;
            string firstDayOfFall = "";
            while (giveMeFive.Count < 5 && maxLoop <= coldDays.Count())
            {
                if (giveMeFive.Count == 0 && counter <= coldDays.Count() - 2) // Get two values at start to be able to compare
                {
                    giveMeFive.Add(coldDays[counter]);
                    counter++;
                }
                giveMeFive.Add(coldDays[counter]);
                if (coldDays[counter].DayInt != coldDays[counter - 1].DayInt + 1) // if this day is not in succession from the previous, clear list
                {
                    giveMeFive.Clear();
                }
                maxLoop++;
            }
            SetCursorPosListUpper();
            if (giveMeFive.Count() == 5)
            {
                firstDayOfFall = monthNames[giveMeFive[0].MonthInt - 1] + " " + giveMeFive[0].DayInt.ToString() + "  -  First day of Autumn";
                Console.Write(firstDayOfFall);
                SetCursorPosListUpper(1);
                Console.Write("Done by creating a new list that only includes days with eligible temperature,");
                SetCursorPosListUpper(2);
                Console.Write("then passing to another list only if the new date is in succession, else clear the list");
                SetCursorPosListUpper(3);
                Console.Write("when the indexer reaches the count of the eligible days without having five counts");
                SetCursorPosListUpper(4);
                Console.Write("it will procede to a message of failure, otherwise it will break search once five is found.");

            }
            else
            {
                Console.Write("No suitable date found");
            }
            Console.SetCursorPosition(0, 0);
        }
        public static void AverageDayData(List<MeasurePoint> measurePoints, int yearInt, int monthInt, int dayInt, string outIn)
        {
            int countPoints = 0;
            SetCursorPosList();
            var onlyOut = measurePoints.Where(a => a.InOut == "Ute" && a.YearInt == yearInt && a.MonthInt == monthInt && a.DayInt == dayInt);
            var onlyIn = measurePoints.Where(a => a.InOut == "Inne" && a.YearInt == yearInt && a.MonthInt == monthInt && a.DayInt == dayInt);
            double avgTempOut = 0.0;
            int avgMoistOut = 0;
            double avgTempIn = 0.0;
            int avgMoistIn = 0;
            int roundValue = 0;
            if (onlyOut.Any(a => a.DayInt == dayInt))
            {
                if (outIn == "Ute")
                {
                    foreach (var m in onlyOut)
                    {
                        Gfx.SetLeftColor();
                        avgTempOut += m.Temp.Value;
                        avgMoistOut += m.Moist.Value;
                        MoveListBuffer();
                        SetCursorPosList();
                        Console.Write(m.HourInt + ":" + m.MinuteInt + ":" + m.SecondInt + " - " + m.Temp.Value);
                        roundValue = (int)Math.Round(m.Temp.Value, 0, MidpointRounding.AwayFromZero);
                        PlotBlock(roundValue, Statics.tempOut, 0, 10, 17);
                    }
                    avgTempOut = avgTempOut / onlyOut.Count();
                    avgTempOut = Math.Round(avgTempOut, 2);
                    avgMoistOut /= onlyOut.Count();
                }
            }
            if (onlyIn.Any(a => a.DayInt == dayInt))
            {
                if (outIn == "Inne")
                {
                    foreach (var m in onlyIn)
                    {
                        Gfx.SetLeftColor();
                        avgTempIn += m.Temp.Value;
                        avgMoistIn += m.Moist.Value;
                        MoveListBuffer();
                        SetCursorPosList();
                        Console.Write(m.HourInt + ":" + m.MinuteInt + ":" + m.SecondInt + " - " + m.Temp.Value);
                        roundValue = (int)Math.Round(m.Temp.Value, 0, MidpointRounding.AwayFromZero);
                        PlotBlock(roundValue, Statics.tempIn, 0, 10, 17);
                    }
                    avgTempIn = avgTempIn / onlyIn.Count();
                    avgTempIn = Math.Round(avgTempIn, 2);
                    avgMoistIn /= onlyIn.Count();
                }
            }
            if (onlyOut.Any(a => a.DayInt == dayInt) || onlyIn.Any(a => a.DayInt == dayInt))
            {
                MoveListBuffer();
                SetCursorPosList();
                string thisDay = yearInt + "-" + monthInt + "-" + dayInt;
                Gfx.SetLeftColor();
                if (outIn == "Ute")
                {
                    Console.Write("The average temperature outdoor " + thisDay + " was: " + avgTempOut);
                }
                else if (outIn == "Inne")
                {
                    Console.Write("The average temperature indoor " + thisDay + " was: " + avgTempIn);
                }
                MoveListBuffer();
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    MoveListBuffer();
                }
                SetCursorPosList();
                Console.WriteLine("Could not retrieve data for " + yearInt + "-" + monthInt + "-" + dayInt);
            }
        }
        public static List<DayMeasure> AverageToList(List<MeasurePoint> measurePoints, List<DayMeasure> dayList, int monthInt, int dayInt)
        {
            int countPoints = 0;
            int yearInt = 2016;

            var onlyOut = measurePoints.Where(a => a.InOut == "Ute" && a.YearInt == yearInt && a.MonthInt == monthInt && a.DayInt == dayInt);
            var onlyIn = measurePoints.Where(a => a.InOut == "Inne" && a.YearInt == yearInt && a.MonthInt == monthInt && a.DayInt == dayInt);
            double avgTempOut = 0.0;
            int avgMoistOut = 0;
            double avgTempIn = 0.0;
            int avgMoistIn = 0;

            if (onlyOut.Any(a => a.DayInt == dayInt))
            {
                foreach (var m in onlyOut)
                {
                    avgTempOut += m.Temp.Value;
                    avgMoistOut += m.Moist.Value;
                }
                avgTempOut = avgTempOut / onlyOut.Count();
                avgTempOut = Math.Round(avgTempOut, 2, MidpointRounding.AwayFromZero);
                avgMoistOut /= onlyOut.Count();
            }
            if (onlyIn.Any(a => a.DayInt == dayInt))
            {
                foreach (var m in onlyIn)
                {
                    avgTempIn += m.Temp.Value;
                    avgMoistIn += m.Moist.Value;
                }
                avgTempIn = avgTempIn / onlyIn.Count();
                avgTempIn = Math.Round(avgTempIn, 2, MidpointRounding.AwayFromZero);
                avgMoistIn /= onlyIn.Count();
            }
            if (onlyOut.Any(a => a.DayInt == dayInt) || onlyIn.Any(a => a.DayInt == dayInt))
            {
                SetCursorPosList();
                Console.Write("Reading data for: " + yearInt + "-" + monthInt + "-" + dayInt);
                MoveListBuffer();
                dayList.Add(new DayMeasure(yearInt, monthInt, dayInt, avgTempIn, avgTempOut, avgMoistIn, avgMoistOut));
            }
            return dayList;
        }
        public static void PresentAverage(List<DayMeasure> dayList, string plotSelected)
        {
            int pauseSwitch = 0;
            foreach (DayMeasure d in dayList)
            {
                pauseSwitch++;
                SetCursorPosList();
                Gfx.SetLeftColor();
                switch (plotSelected)
                {
                    case "TempOut":
                        Console.Write(d.YearInt + "-" + d.MonthInt + "-" + d.DayInt + "\tThe average outdoor temperature was: " + d.AvgTempOut);
                        PlotBlock((int)d.AvgTempOut, Statics.tempOut, 0, 10, 17);
                        break;
                    case "TempIn":
                        Console.Write(d.YearInt + "-" + d.MonthInt + "-" + d.DayInt + "\tThe average indoor temperature was: " + d.AvgTempIn);
                        PlotBlock((int)d.AvgTempIn, Statics.tempIn, 21, 23, 25);
                        break;
                    case "MoistOut":
                        Console.Write(d.YearInt + "-" + d.MonthInt + "-" + d.DayInt + "\tThe average outdoor moisture was: " + d.AvgMoistOut);
                        PlotBlock(d.AvgMoistOut, Statics.moistOut, 70, 80, 90);
                        break;
                    case "MoistIn":
                        Console.Write(d.YearInt + "-" + d.MonthInt + "-" + d.DayInt + "\tThe average indoor moisture was: " + d.AvgMoistIn);
                        PlotBlock(d.AvgMoistIn, Statics.moistIn, 20, 30, 40);
                        break;
                }
                if (pauseSwitch >= 35)
                {
                    Gfx.SetLeftColor();
                    MoveListBuffer();
                    SetCursorPosList();
                    Console.Write("-= Press Any Key to Continue =-");
                    Console.ReadKey();
                    pauseSwitch = 0;
                }

                MoveListBuffer();
                Thread.Sleep(20);
            }
            //            MovePlotBuffer();
        }
        public static void SetCursorPosList()
        {
            Console.SetCursorPosition(Statics.listPosX, Statics.listPosY);
        }
        public static void SetCursorPosListUpper(int i = 0)
        {
            Console.SetCursorPosition(Statics.listPosX, Statics.listPosYTop+i);
        }
        public static void MoveListBuffer()
        {
            Console.BackgroundColor = (ConsoleColor)Statics.bgColor;
            Console.MoveBufferArea(5, 13, 100, 35, 5, 12);
        }
        public static void MovePlotBuffer()
        {
            Console.BackgroundColor = (ConsoleColor)Statics.bgPlotColor;
            Console.MoveBufferArea(115, 4, 82, 42, 113, 4);
        }
        public static void PlotBlock(int value, string plotSelected, int low, int med, int high)
        {
            int lv1Col = 0;
            int lv2Col = 0;
            int lv3Col = 0;
            int lv4Col = 0;
            switch (plotSelected)
            {
                case "TempOut":
                    lv1Col = 9;
                    lv2Col = 11;
                    lv3Col = 6;
                    lv4Col = 10;
                    break;
                case "TempIn":
                    lv1Col = 14;
                    lv2Col = 6;
                    lv3Col = 10;
                    lv4Col = 12;
                    break;
                case "MoistOut":
                    lv1Col = 11;
                    lv2Col = 3;
                    lv3Col = 9;
                    lv4Col = 1;
                    break;
                case "MoistIn":
                    lv1Col = 15;
                    lv2Col = 7;
                    lv3Col = 10;
                    lv4Col = 2;
                    break;
                case "MoldRisk":
                    lv1Col = 3; // DarkCyan
                    lv2Col = 2;  // DarkGreen
                    lv3Col = 6; // DarkYellow
                    lv4Col = 4;  // DarkRed
                    break;
            }
            // 0;   // Black
            // 8;   // DarkGray
            // 7;   // Gray
            // 15;   // White
            // 1;   // DarkBlue
            // 9;   // Blue
            // 3;   // DarkCyan
            // 11;   // Cyan
            // 2;   // DarkGreen
            // 10;   // Green
            // 6;   // DarkYellow
            // 14;   // Yellow
            // 5;   // DarkMagenta
            // 13;   // Magenta
            // 4;   // DarkRed
            // 12;   // Red
            if (value < low)
            {
                Console.ForegroundColor = (ConsoleColor)lv1Col;
            }
            else if (value >= low && value <= med)
            {
                Console.ForegroundColor = (ConsoleColor)lv2Col;
            }
            else if (value > med && value <= high)
            {
                Console.ForegroundColor = (ConsoleColor)lv3Col;
            }
            else
            {
                Console.ForegroundColor = (ConsoleColor)lv4Col;
            }
            MovePlotBuffer();
            switch (plotSelected)
            {
                case "TempOut":
                    Console.SetCursorPosition(195, 36 - value);
                    break;
                case "TempIn":
                    Console.SetCursorPosition(195, 40 - (value * 2) + 30);
                    break;
                case "MoistOut":
                    Console.SetCursorPosition(195, 40 - (value / 3));
                    break;
                case "MoistIn":
                    Console.SetCursorPosition(195, 40 - (value / 2));
                    break;
                case "MoldRisk":
                    Console.SetCursorPosition(195, 40 - (value / 3));
                    break;
            }

            Console.Write(value);

        }
        public static void ReadMoldTextfile()
        {
            if (File.Exists(Statics.path + Statics.fileMoldRisk))
            {
                List<string> lines = new List<string>();
                using (StreamReader reader = new StreamReader(Statics.path + Statics.fileMoldRisk))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        line = reader.ReadLine();
                        if (line != null)
                        {
                            lines.Add(line);
                        }
                    }
                }
                foreach (string line in lines)
                {
                    SetCursorPosList();
                    Console.Write(line);
                    MoveListBuffer();
                }
                SetCursorPosList();
                Console.Write("Would you like to delete this file? Y/N");
                MoveListBuffer();
                var userInputKey = Console.ReadKey(true);
                if (userInputKey.Key == ConsoleKey.Y)
                {
                    File.Delete(Statics.path + Statics.fileMoldRisk);
                    SetCursorPosList();
                    Console.Write("Boom! Gone!");
                    MoveListBuffer();
                }
                if (userInputKey.Key == ConsoleKey.N)
                {
                    SetCursorPosList();
                    Console.Write("Phew! Close call!   / MoldRisk.txt");
                    MoveListBuffer();
                }
            }
            else
            {
                SetCursorPosList();
                Console.Write("File not found");
                MoveListBuffer();
            }
        }
        public static List<string> ReadAll2(List<string> list)
        {
            using (StreamReader reader = new StreamReader(Statics.path + Statics.file))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        list.Add(line);
                    }
                }
                return list;
            }
        }
        public static IEnumerable<Match> Test2(string text, string pattern)
        {
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);
            SetCursorPosList();
            Console.WriteLine("Number of matches: " + matches.Count);
            IEnumerable<Match> numMatches = matches.Cast<Match>();  // Cast matches to IENumerable<Match> for Linq
            return numMatches;
        }
    }
}
