using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TeamF_WeatherAnalysis.Models;

namespace TeamF_WeatherAnalysis.Helpers
{
    internal class Gfx
    {
        public static void InitGfxFirst()
        {
            Console.SetBufferSize(Statics.screenWidth, Statics.screenHeight);
            Console.SetWindowSize(Statics.screenWidth, Statics.screenHeight);
            Console.Title = "Weather Data Analyser v1.0";
            Console.CursorVisible = false;
            Console.BackgroundColor = (ConsoleColor)Statics.bgColor;
            Console.ForegroundColor = (ConsoleColor)Statics.bgColor;
            Console.Clear();
            //InitGfxInclude();
            Menu2222(0, 0);
            Console.SetCursorPosition(0, 0);
            Gfx.SetLeftColor();
        }
        public static void InitGfxInclude()
        {
            SplitColor();
            SetLeftColor();
        }
        public static void InitGfx()
        {
            InitGfxInclude();
            Menu.DrawMenu();
            Console.SetCursorPosition(0, 0);
        }
        public static void InitGfxSwitch()
        {
            Console.BackgroundColor = (ConsoleColor)Statics.bgColor;
            Console.Clear();
            Menu2222(0, 0);
            InitGfx();
        }
        public static void ThemeSelector()
        {
            int i = 0;
            Console.SetCursorPosition(Statics.listPosX, Statics.listPosYTop + i); i++;
            Console.Write("Select theme colors, Background / Foreground");
            Console.SetCursorPosition(Statics.listPosX, Statics.listPosYTop + i); i++;
            Console.Write("1. Dark Magenta / Yellow   - Modern Style");
            Console.SetCursorPosition(Statics.listPosX, Statics.listPosYTop + i); i++;
            Console.Write("2. Dark Green  / White     - Retro Terminal-style");
            Console.SetCursorPosition(Statics.listPosX, Statics.listPosYTop + i); i++;
            Console.Write("3. Dark Blue / White       - Commodore 64-style");
            Console.SetCursorPosition(Statics.listPosX, Statics.listPosYTop + i); i++;
            Console.Write("4. Gray / Black            - ZX Spectrum-style");
            Console.SetCursorPosition(Statics.listPosX, Statics.listPosYTop + i); i++;
            Console.Write("5. Dark Blue / Dark Red    - Madness * ONLY For Clinically Insane *");
            var userInputKey = Console.ReadKey(true);
            if (userInputKey.Key == ConsoleKey.D1)
            {
                Statics.bgColor = 5;
                Statics.fgColor = 14;
            }
            if (userInputKey.Key == ConsoleKey.D2)
            {
                Statics.bgColor = 2;
                Statics.fgColor = 15;
            }
            if (userInputKey.Key == ConsoleKey.D3)
            {
                Statics.bgColor = 9;
                Statics.fgColor = 15;
            }
            if (userInputKey.Key == ConsoleKey.D4)
            {
                Statics.bgColor = 8;
                Statics.fgColor = 0;
            }
            if (userInputKey.Key == ConsoleKey.D5)
            {
                Statics.bgColor = 1;
                Statics.fgColor = 4;
            }
            InitGfxSwitch();
        }
        public static void SwitchFromGray()
        {
            Statics.bgColor = 5;
            Statics.fgColor = 14;
            InitGfxSwitch();
        }
        public static void SetLeftColor()
        {
            Console.BackgroundColor = (ConsoleColor)Statics.bgColor;
            Console.ForegroundColor = (ConsoleColor)Statics.fgColor;
        }
        public static void SplitColor()
        {
            Console.BackgroundColor = (ConsoleColor)Statics.bgColor;
            //123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 12345 = 105
            //▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
            string clearString = new string(' ', 105);
            for (int i = 11; i < Console.WindowHeight - 2; i++)
            {
                Console.SetCursorPosition(Statics.listPosX, i);
                Console.Write(clearString);
            }
            Console.BackgroundColor = (ConsoleColor)Statics.bgPlotColor;
            //123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 1234 = 84
            //▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
            clearString = new string(' ', 84);
            for (int i = 3; i < 47; i++)
            {
                Console.SetCursorPosition(113, i);
                Console.Write(clearString);
            }
        }

        public static char GetRandomChar()
        {
            string japaneseChr = " ゠ ァ ア ィ イ ゥ ウ ェ エ ォ オ カ ガ キ ギ ク グ ケ ゲ コ ゴ サ ザ シ ジ ス ズ セ ゼ ソ ゾ タ ダ チ ヂ ッ ツ ヅ テ デ " +
                "ト ド ナ ニ ヌ ネ ノ ハ バ パ ヒ ビ ピ フ ブ プ ヘ ベ ペ ホ ボ ポ マ ミ ム メ モ ャ ヤ ュ ユ ョ ヨ ラ リ ル レ ロ ヮ ワ ヰ ヱ ヲ ン ヴ ヵ " +
                "ヶ ヷ ヸ ヹ ヺ ・ ー ヽ ヾ ヿ                                                                                                   " +
                "                                                                                                                              " +
                "                                                                                                                              " +
                "                                                                                                                              " +
                "                                                                                                                              " +
                "                                                                                                                              " +
                "                                                                                                                              " +
                "                                                                                                                               ";
            char[] allChar = japaneseChr.ToArray();
            Random rnd = new Random();
            char rndChar = allChar[rnd.Next(allChar.Length)];
            return rndChar;
        }
        public static string GetRandomString()
        {
            string japaneseChr = "゠ ァ ア ィ イ ゥ ウ ェ エ ォ オ カ ガ キ ギ ク グ ケ ゲ コ ゴ サ ザ シ ジ ス ズ セ ゼ ソ ゾ タ ダ チ " +
                "ヂ ッ ツ ヅ テ デ ト ド ナ ニ ヌ ネ ノ ハ バ パ ヒ ビ ピ フ ブ プ ヘ ベ ペ ホ ボ ポ マ ミ ム メ モ ャ ヤ ュ ユ ョ ヨ ラ リ " +
                "ル レ ロ ヮ ワ ヰ ヱ ヲ ン ヴ ヵ ヶ ヷ ヸ ヹ ヺ ・ ー ヽ ヾ ヿ 😅 💖";
            string[] allChar = japaneseChr.Split(' ');
            Random rnd = new Random();
            string rndChar = allChar[rnd.Next(allChar.Length)];
            return rndChar;
        }
        public static void FillJapanese()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Random rnd = new Random();
            char rndJap = ' ';
            int[] randomCol = { 1, 9, 3}; //, 11, 15 

            int maxX = Console.WindowWidth - 1;
            int maxY = Console.WindowHeight;
            while (true)
            {
                Console.ForegroundColor = (ConsoleColor)randomCol[rnd.Next(3)];
                rndJap = GetRandomChar();
                Console.SetCursorPosition(rnd.Next(maxX), rnd.Next(maxY));
                Console.Write(rndJap);
            }
        }
        public static void FillJapanese2()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Random rnd = new Random();
            char rndJap = ' ';
            int[] randomCol = { 10, 2, 0 }; // 8 darkgray
            int maxX = Console.WindowWidth - 1;
            int maxY = Console.WindowHeight;
            string newRow = "";
            while (true)
            {
                for (int i = 0;  i < maxX; i++)
                {
                    newRow += GetRandomChar();
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.SetCursorPosition(0,0);
                Console.Write(newRow);
                Console.MoveBufferArea(0, 0, maxX, maxY - 1, 0, 1);
                newRow = "";
                Thread.Sleep(40);
            }
        }

        public static void FillJapaneseWithEmoji()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Random rnd = new Random();
            string rndJap = "";
            int[] randomCol = { 10, 2, 8 };
            int maxX = Console.WindowWidth - 1;
            int maxY = Console.WindowHeight;
            while (true)
            {
                Console.ForegroundColor = (ConsoleColor)randomCol[rnd.Next(3)];
                rndJap = GetRandomString();
                if (rndJap == "😅")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(rnd.Next(maxX), rnd.Next(maxY - 1));
                    Console.Write(rndJap);
                }
                else if (rndJap == "💖")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(rnd.Next(maxX), rnd.Next(maxY - 1));
                    Console.Write(rndJap);
                }
                else
                {
                    Console.SetCursorPosition(rnd.Next(maxX), rnd.Next(maxY));
                    Console.Write(rndJap);
                }
            }
        }
        public static void Menu2222(int gfxLeft, int gfxTop)
        {
            // columns: 200, rows: 50.
            Console.SetCursorPosition(gfxLeft, gfxTop + 0);
            Console.ForegroundColor = (ConsoleColor)Statics.bgColor;
            Console.BackgroundColor = (ConsoleColor)Statics.bgPlotColor;
            Console.Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 1);
            Console.Write("▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 2);
            Console.Write("▒▒▓▓");
            Console.SetCursorPosition(gfxLeft + 109, gfxTop + 2);
            Console.Write("▓▓▒▓▓");
            Console.SetCursorPosition(gfxLeft + 114, gfxTop + 2);
            Console.Write("                                                                                  ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 2);
            Console.Write("▓▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 3);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 3);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 3);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 3);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 4);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 4);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 4);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 4);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 5);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 5);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 5);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 5);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 6);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 6);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 6);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 6);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 7);
            Console.Write("▒▒▓▓");
            Console.SetCursorPosition(gfxLeft + 109, gfxTop + 7);
            Console.Write("▓▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 7);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 7);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 8);
            Console.Write("▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 8);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 8);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 9);
            Console.Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 9);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 9);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 10);
            Console.Write("▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 10);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 10);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 11);
            Console.Write("▒▒▓▓");
            Console.SetCursorPosition(gfxLeft + 109, gfxTop + 11);
            Console.Write("▓▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 11);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 11);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 12);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 12);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 12);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 12);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 13);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 13);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 13);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 13);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 14);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 14);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 14);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 14);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 15);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 15);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 15);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 15);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 16);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 16);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 16);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 16);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 17);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 17);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 17);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 17);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 18);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 18);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 18);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 18);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 19);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 19);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 19);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 19);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 20);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 20);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 20);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 20);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 21);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 21);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 21);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 21);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 22);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 22);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 22);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 22);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 23);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 23);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 23);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 23);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 24);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 24);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 24);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 24);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 25);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 25);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 25);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 25);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 26);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 26);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 26);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 26);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 27);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 27);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 27);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 27);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 28);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 28);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 28);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 28);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 29);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 29);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 29);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 29);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 30);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 30);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 30);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 30);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 31);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 31);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 31);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 31);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 32);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 32);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 32);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 32);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 33);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 33);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 33);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 33);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 34);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 34);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 34);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 34);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 35);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 35);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 35);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 35);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 36);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 36);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 36);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 36);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 37);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 37);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 37);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 37);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 38);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 38);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 38);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 38);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 39);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 39);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 39);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 39);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 40);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 40);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 40);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 40);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 41);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 41);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 41);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 41);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 42);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 42);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 42);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 42);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 43);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 43);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 43);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 43);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 44);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 44);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 44);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 44);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 45);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 45);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 45);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 45);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 46);
            Console.Write("▒▒▓");
            Console.SetCursorPosition(gfxLeft + 110, gfxTop + 46);
            Console.Write("▓▒▓");
            Console.SetCursorPosition(gfxLeft + 113, gfxTop + 46);
            Console.Write("                                                                                    ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 46);
            Console.Write(" ▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 47);
            Console.Write("▒▒▓▓");
            Console.SetCursorPosition(gfxLeft + 109, gfxTop + 47);
            Console.Write("▓▓▒▓▓");
            Console.SetCursorPosition(gfxLeft + 114, gfxTop + 47);
            Console.Write("                                                                                  ");
            Console.SetCursorPosition(gfxLeft + 196, gfxTop + 47);
            Console.Write("▓▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 48);
            Console.Write("▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒");

            Console.SetCursorPosition(gfxLeft, gfxTop + 49);
            Console.Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        }

    }
}
