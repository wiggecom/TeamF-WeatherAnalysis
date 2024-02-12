using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamF_WeatherAnalysis.Models;

namespace TeamF_WeatherAnalysis.Helpers
{
    internal class Menu
    {
        public static void DrawMenu()
        {
            Console.SetCursorPosition(Statics.listPosX, 3);
            Console.Write("F1 - Date for Autumn           F4 - Avg Outdoor Moisture         F7 - Outdoor by temperature");
            Console.SetCursorPosition(Statics.listPosX, 4);
            Console.Write("F2 - Avg Temp Outdoor          F5 - Avg Indoor Moisture          F8 - Mold Risk Outdoor");
            Console.SetCursorPosition(Statics.listPosX, 5);
            Console.Write("F3 - Avg Temp Indoor           F6 - Search Date                  F9 - Read MoldRisk.txt");
            Console.SetCursorPosition(Statics.listPosX, 6);
            Console.Write("DEL - Exit (Blue Style)       F10 - Select Theme                ESC - Exit (Green Style)");
            Console.SetCursorPosition(0, 0);
        }
        public static bool MenuKeys(List<MeasurePoint> measurePoints, List<DayMeasure> dayList)
        {
            var userInputKey = Console.ReadKey(true);

            if (userInputKey.Key == ConsoleKey.F1)
            {
                Gfx.InitGfx();
                Lab.CheckFall(dayList);
                Console.BackgroundColor = (ConsoleColor)Statics.bgColor;
                return true;

            }
            if (userInputKey.Key == ConsoleKey.F2)
            {
                Gfx.InitGfx();
                Lab.PresentAverage(dayList, Statics.tempOut);
                Gfx.SetLeftColor();
                EoF();
                return true;
            }
            if (userInputKey.Key == ConsoleKey.F3)
            {
                Gfx.InitGfx();
                Lab.PresentAverage(dayList, Statics.tempIn);
                Console.BackgroundColor = (ConsoleColor)Statics.bgColor;
                EoF();
                return true;
            }
            if (userInputKey.Key == ConsoleKey.F4)
            {
                Gfx.InitGfx();
                Lab.PresentAverage(dayList, Statics.moistOut);
                Console.BackgroundColor = (ConsoleColor)Statics.bgColor;
                EoF();
                return true;
            }
            if (userInputKey.Key == ConsoleKey.F5)
            {
                Gfx.InitGfx();
                Lab.PresentAverage(dayList, Statics.moistIn);
                Console.BackgroundColor = (ConsoleColor)Statics.bgColor;
                EoF();
                return true;
            }
            if (userInputKey.Key == ConsoleKey.F6)
            {
                Gfx.InitGfx();
                SpecificDate(measurePoints);
                Console.BackgroundColor = (ConsoleColor)Statics.bgColor;
                EoF();
                return true;
            }
            if (userInputKey.Key == ConsoleKey.F7)
            {
                Gfx.InitGfx();
                Lab.SortedList(dayList);
                Console.BackgroundColor = (ConsoleColor)Statics.bgColor;
                EoF();
                return true;
            }
            if (userInputKey.Key == ConsoleKey.F8)
            {
                Gfx.InitGfx();
                Lab.SortedMoldOut(dayList);
                Console.BackgroundColor = (ConsoleColor)Statics.bgColor;
                return true;
                //EoF();
            }
            if (userInputKey.Key == ConsoleKey.F9)
            {
                Gfx.InitGfx();
                Lab.ReadMoldTextfile();
                Console.BackgroundColor = (ConsoleColor)Statics.bgColor;
                return true;
                //EoF();
            }
            if (userInputKey.Key == ConsoleKey.F10)
            {
                Gfx.InitGfx();
                Gfx.ThemeSelector();
                Console.BackgroundColor = (ConsoleColor)Statics.bgColor;
                return true;
                //EoF();
            }
            if (userInputKey.Key == ConsoleKey.Escape)
            {
                Gfx.FillJapanese2();
                Console.BackgroundColor = (ConsoleColor)Statics.bgColor;
                return false;
            }
            if (userInputKey.Key == ConsoleKey.Delete)
            {
                Gfx.FillJapanese();
                Console.BackgroundColor = (ConsoleColor)Statics.bgColor;
                return false;
            }

            return true;

        }
        public static void EoF()
        {
            Gfx.SetLeftColor();
            Lab.MoveListBuffer();
            Lab.SetCursorPosList();
            Console.Write("End of file");
            Lab.MoveListBuffer();
        }
        public static void SpecificDate(List<MeasurePoint> measurePoints)
        {
            int yearInt = 0;
            int monthInt = 0;
            int dayInt = 0;
            string outIn = "";
            Console.SetCursorPosition(Statics.listPosX, Statics.listPosYTop);
            Console.Write("Enter Year: ");
            yearInt = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(Statics.listPosX, Statics.listPosYTop+1);
            Console.Write("Enter Month: ");
            monthInt = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(Statics.listPosX, Statics.listPosYTop+2);
            Console.Write("Enter Day: ");
            dayInt = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(Statics.listPosX, Statics.listPosYTop + 3);
            Console.Write("And Finally, Outdoors or Indoors (O / I): ");
            var userInputKey = Console.ReadKey(true);
            if (userInputKey.Key == ConsoleKey.O)
            {
                outIn = "Ute";
            }
            if (userInputKey.Key == ConsoleKey.U)
            {
                outIn = "Ute";
            }
            if (userInputKey.Key == ConsoleKey.I)
            {
                outIn = "Inne";
            }
            Lab.AverageDayData(measurePoints, yearInt, monthInt, dayInt, outIn);

        }
    }
}
