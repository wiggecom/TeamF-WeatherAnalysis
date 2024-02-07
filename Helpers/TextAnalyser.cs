using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TeamF_WeatherAnalysis.Models;

namespace TeamF_WeatherAnalysis.Helpers
{
    internal class TextAnalyser
    {
        public static void Test(string text, string pattern, string yearStr, string monthStr, string dayStr)
        {
            int year = 0;
            int month = 0;
            int day = 0;
            Regex regex = new Regex(pattern);
            RegexOptions options = RegexOptions.IgnoreCase;
            MatchCollection matches = regex.Matches(text);
            if (matches.Count > 0)
            {
                
                //Console.WriteLine("Number of matches: " + matches.Count);
                foreach (Match match in matches)
                {
                    year = 0;
                    month = 0;
                    day = 0;
                    int hour = 0;
                    int minute = 0;
                    int second = 0;
                    double temp = 0.0;
                    int moist = 0;
                    bool indoor = false;
                    if (match.Groups.Count > 0)
                    {
                        string newDate = "";
                        foreach (Group group in match.Groups)
                        {
                            switch (group.Name)
                                {
                                case "year":
                                    if (group.Value == yearStr)
                                    {
                                        year = int.Parse(group.Value);
                                    }
                                    break;
                                case "month":
                                    if (group.Value == monthStr)
                                    {
                                        month = int.Parse(group.Value);
                                    }
                                    break;
                                case "day":
                                    if (group.Value == dayStr)
                                    {
                                        day = int.Parse(group.Value);
                                    }
                                    break;
                                case "hour":
                                        hour = int.Parse(group.Value);
                                    break;
                                case "minute":
                                        minute = int.Parse(group.Value);
                                    break;
                                case "second":
                                        second = int.Parse(group.Value);
                                    break;
                                case "indoor":
                                    if (group.Value == "Inne")
                                    {
                                        indoor = true;
                                    }
                                    else
                                    {
                                        indoor = false;
                                    }
                                    break;
                                case "temp":
                                    string tempStr = group.Value;
                                    tempStr = tempStr.Replace('.', ',');
                                    temp = double.Parse(tempStr);
                                    break;
                                case "moist":
                                    moist = int.Parse(group.Value);
                                    break;
                            }
                        }
                    }
                    // Output to console
                    if (year != 0 && month != 0 && day != 0)
                    {
                        if (indoor == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor= ConsoleColor.Yellow;
                        }
                        Console.Write(year + "\\" + month + "\\" + day + " - " + hour + ":" + minute + ":" + second + " ");
                        if (temp > 15)
                        {
                            Console.ForegroundColor=ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        Console.Write("\tT:"+ temp);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(" - ");
                        if (moist > 78)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        Console.WriteLine("M:" + moist);
                        Console.ResetColor();
                    }
                }
            }
        }
        public static double MoldRiskCalc(double temp, double moisture)
        {
            // ((luftfuktighet -78) * (Temp/15))/0,22
            double result = ((moisture - 78) * (temp / 15)) / 0.22;
            Console.WriteLine(result);
            return result;
        }
    }
}
