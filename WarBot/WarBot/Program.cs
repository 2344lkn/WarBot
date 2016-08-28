using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;

namespace WarBot
{
    class Program
    {
        public static void Main(string[] args) => new Program().Start(args);

        private const string AppName = "WarBot";
        private const string AppUrl = "https://github.com/2344lkn/WarBot";
        public const string Version = "1.1.4";

        private static bool ChatOn = false;

        private DiscordClient _bot;

        private void Start(string[] args)
        {
            Console.Title = $"{AppName} {Version}";

            Core.Intro();

            _bot = new DiscordClient(x =>
            {
                x.AppName = AppName;
                //x.MessageCacheSize = 10;
                //x.EnablePreUpdateEvents = true;
            });

            _bot.MessageReceived += (s, e) =>
            {
                #region Bot Commands
                // Bot Command Prefix
                if (e.Message.Text.StartsWith("!"))
                {
                    if (e.Message.IsAuthor)
                    {
                        Console.WriteLine("[BOT] " + e.Message.Text);
                        // Do Nothing
                    }
                    else
                    {
                        if (e.Message.Text == "!help")
                        {
                            Core.WriteLineColoured(3, 2, e.User.ToString() + " [CMD] " + e.Message.Text);

                            e.Channel.SendMessage(Core.HelpCmd());
                        }
                    }
                }
                else
                {
                    // NCalc
                    // AI Chat
                }
                #endregion
                //Console.WriteLine(e.User.ToString());
            };

            // Needs to be last, nothing will run after ExecuteAndWait
            _bot.ExecuteAndWait(async () =>
            {
                while (true)
                {
                    try
                    {
                        await _bot.Connect("bot.token");

                        Console.WriteLine("[Connected] " + $"Connected as {_bot.CurrentUser.Name} (Id {_bot.CurrentUser.Id})");
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Attempting to reconnect...");
                        await Task.Delay(3000);
                    }
                }
            });
        }
    }
}
