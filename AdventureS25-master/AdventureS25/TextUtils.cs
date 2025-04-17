using System;
using System.Threading;

namespace AdventureS25
{
    public static class TextUtils
    {
        public static void TypeText(string text, bool newLine = true)
        {
            int defaultDelay = 18; // ms
            int commaDelay = 120;
            int periodDelay = 220;
            int exclamationDelay = 220;
            int questionDelay = 220;
            int ellipsisDelay = 350;
            int quoteDelay = 40;
            int dashDelay = 60;

            bool skip = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (!skip && Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                    {
                        skip = true;
                    }
                }

                char c = text[i];
                Console.Write(c);
                Console.Out.Flush();

                int delay = defaultDelay;
                if (c == ',') delay = commaDelay;
                else if (c == '.' || c == '!' || c == '?')
                {
                    if (c == '.') delay = periodDelay;
                    else if (c == '!') delay = exclamationDelay;
                    else if (c == '?') delay = questionDelay;
                }
                else if (c == '"' || c == '\'') delay = quoteDelay;
                else if (c == '-' || c == '—') delay = dashDelay;
                else if (char.IsWhiteSpace(c)) delay = 0;

                if (!skip && delay > 0)
                {
                    int elapsed = 0;
                    while (elapsed < delay)
                    {
                        if (Console.KeyAvailable)
                        {
                            var key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Enter)
                            {
                                skip = true;
                                break;
                            }
                        }
                        Thread.Sleep(10);
                        elapsed += 10;
                    }
                }
            }
            if (newLine)
                Console.WriteLine();
        }
    }
}
