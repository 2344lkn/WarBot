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
                @" __      __             __________        __   " + "\r\n" +
                @"/  \    /  \_____ ______\______   \ _____/  |_ " + "\r\n" +
                @"\   \/\/   /\__  \ _  __ \    |  _//  _ \   __|" + "\r\n" +
                @" \        /  / __ \|  | \/    |   (  <_> )  |" + "\r\n" +
                @"  \__/\  /  (____  /__|  |______  /\____/|__|" + "\r\n" +
                @"       \/        \/             \/         v1" + "\r\n" +
                "\r\n" +
                "[List of Commands] \r\n" +
                " ------------------ \r\n" +
                // Core
                "[Core Commands] \r\n" +
                " !help - Shows a list of commands. \r\n" +
                " !about - Displays Version and Info about the bot. \r\n" +
                " !exit - Shuts down the bot. \r\n" +
                "\r\n" +
                // Crypto
                "[Crypto] \r\n" +
                " ~ Polynomial Encryption \r\n" +
                " !polye <message> <password> \r\n" +
                "   Password must be 5 characters or greater. \r\n" +
                " ~ Polynomial Decryption \r\n" +
                " !polyd <encryptedString> <password> \r\n" +
                "\r\n" +
                // AI
                "[AI] \r\n" +
                " ~ AI Chat \r\n" +
                " !chat on \r\n" +
                " !chat off ```";

            return help;
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
