using System;

namespace WarBot
{
    class Core
    {
        public static void Intro()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@" __      __             __________        __   ");
            Console.WriteLine(@"/  \    /  \_____ ______\______   \ _____/  |_ ");
            Console.WriteLine(@"\   \/\/   /\__  \ _  __ \    |  _//  _ \   __|");
            Console.WriteLine(@" \        /  / __ \|  | \/    |   (  <_> )  |");
            Console.WriteLine(@"  \__/\  /  (____  /__|  |______  /\____/|__|");
            Console.WriteLine(@"       \/        \/             \/         v1");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static string HelpCmd()
        {
            string help = "``` Artificial Intelligence WarBot " + Program.Version + "\r\n" +
                "\r\n" +
                "**Bot Commands** \r\n" +
                "Core Commands: \r\n" +
                " !help - Shows a list of commands. \r\n" +
                " !about - Displays Version and Info about the bot. \r\n" +
                "\r\n" +
                "Crypto Commands: \r\n" +
                " !polye [message] [password] - Polynomial Encryption \r\n" +
                " !polyd [encryptedString] [password] - Polynomial Decryption \r\n" +
                "\r\n" +
                "A.I. Commands: \r\n" +
                " !math [expression] - Mathematical Expression Evaluation\r\n" +
                " !chat on - Turns on AI Chat \r\n" +
                " !chat off - Turns off AI Chat ```";

            return help;
        }

        public static string AboutCmd()
        {
            string about = "``` Artificial Intelligence WarBot " + Program.Version + "\r\n" +
                @" __      __             __________        __   " + "\r\n" +
                @"/  \    /  \_____ ______\______   \ _____/  |_ " + "\r\n" +
                @"\   \/\/   /\__  \ _  __ \    |  _//  _ \   __|" + "\r\n" +
                @" \        /  / __ \|  | \/    |   (  <_> )  |" + "\r\n" +
                @"  \__/\  /  (____  /__|  |______  /\____/|__|" + "\r\n" +
                @"       \/        \/             \/         v1" + "\r\n" +
                "\r\n" +
                "**Change Log** \r\n" +
                "+ Added a tool | * Update / Bugfix | ^ AI Grows Stronger \r\n" +
                " [1.0.0]] WarBot's Working Creation \r\n" +
                " [1.0.1]+ Polynomial Encryption and Decryption \r\n" +
                " [1.0.2]+ Artificial Intelligence Chat \r\n" +
                " [1.0.3]^ Machine Learning(Chat Convos) \r\n" +
                " [1.0.4]* Cleaned up code, Faster and Optimized Bot Structure \r\n" +
                " [1.1.4]] Migrated to Discord.Net \r\n" +
                " [1.1.5]+ Mathematical Expression Evaluation NCalc \r\n" +
                "\r\n" +
                "**Features Under Development** \r\n" +
                " Mathematical Expressions Evaluator \r\n" +
                " UrlScanner \r\n" +
                " Neural Network Base ``` \r\n" +
                "https://github.com/2344lkn/WarBot";

            return about;
        }

        public static void WriteLineColoured(int startColor, int endColor, string text)
        {
            // Set Console Color before Write
            if (startColor == 0)
                Console.ForegroundColor = ConsoleColor.Red;
            if (startColor == 1)
                Console.ForegroundColor = ConsoleColor.Green;
            if (startColor == 2)
                Console.ForegroundColor = ConsoleColor.Gray;
            if (startColor == 3)
                Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine(text);

            // Set Console Color after Write
            if (endColor == 0)
                Console.ForegroundColor = ConsoleColor.Red;
            if (endColor == 1)
                Console.ForegroundColor = ConsoleColor.Green;
            if (endColor == 2)
                Console.ForegroundColor = ConsoleColor.Gray;
            if (endColor == 3)
                Console.ForegroundColor = ConsoleColor.Magenta;
        }
    }
}
