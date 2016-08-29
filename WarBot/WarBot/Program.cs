using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Discord;

namespace WarBot
{
    class Program
    {
        public static void Main(string[] args) => new Program().Start(args);

        private const string AppName = "WarBot";
        private const string AppUrl = "https://github.com/2344lkn/WarBot";
        public const string Version = "1.1.5";

        private static bool ChatOn = false;
        public static string DiscordUser = "2344lkn";

        private DiscordClient _bot;

        private void Start(string[] args)
        {
            Console.Title = $"{AppName} {Version}";
            Core.Intro();

            // Connect Discord Bot
            _bot = new DiscordClient(x =>
            {
                x.AppName = AppName;
                x.MessageCacheSize = 10;
                //x.EnablePreUpdateEvents = true;
            });

            // Load AIML Chat files
            try
            {
                AIML.LoadAIMLFiles();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            // Main bot Loop (Waiting for Discord Messages)
            _bot.MessageReceived += (s, e) =>
            {
                DiscordUser = e.Message.User.ToString();

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
                        #region Core Commands
                        // Help Cmd
                        if (e.Message.Text == "!help")
                        {
                            Core.WriteLineColoured(3, 2, e.User.ToString() + " [CMD] " + e.Message.Text);

                            e.Channel.SendMessage(Core.HelpCmd());
                        }

                        // About Cmd
                        if (e.Message.Text == "!about")
                        {
                            Core.WriteLineColoured(3, 2, e.User.ToString() + " [CMD] " + e.Message.Text);

                            e.Channel.SendMessage(Core.AboutCmd());
                        }

                        // Quit Cmd
                        if (e.Message.Text == "!exit" || e.Message.Text == "!quit" || e.Message.Text == "!disc")
                        {
                            Core.WriteLineColoured(3, 2, e.User.ToString() + " [CMD] " + e.Message.Text);

                            if (e.Message.User.Id.ToString() == "202128606481219585")
                            {
                                e.Channel.SendMessage("Shutting Down.");

                                _bot.Disconnect();
                            }
                            // Do Nothing
                        }
                        #endregion

                        #region Crypto Commands
                        // Polynomial Encryption Cmd
                        if (e.Message.Text.Contains("!polye"))
                        {
                            Core.WriteLineColoured(3, 2, e.User.ToString() + " [CMD] " + e.Message.Text);
                            e.Channel.SendMessage("Polynomial Encryption:");

                            string cmd = e.Message.RawText.Replace("!polye ", "");
                            string[] SplitStr = cmd.Split(null);
                            string PlainTextMsg = SplitStr[0];
                            string Password = SplitStr[1];

                            e.Channel.SendMessage(WarBot.PolyCrypt.polyEncryptTxt(PlainTextMsg, Password));
                        }

                        // Polynomial Decryption Cmd
                        if (e.Message.Text.Contains("!polyd"))
                        {
                            Core.WriteLineColoured(3, 2, e.User.ToString() + " [CMD] " + e.Message.Text);
                            e.Channel.SendMessage("Polynomial Decryption:");

                            string cmd = e.Message.RawText.Replace("!polyd ", "");
                            string[] SplitStr = cmd.Split(null);
                            string EncryptedMsg = SplitStr[0];
                            string Password = SplitStr[1];

                            e.Channel.SendMessage(WarBot.PolyCrypt.polyDecryptTxt(EncryptedMsg, Password));
                        }
                        #endregion

                        #region AI Commands
                        // AI Chat On
                        if (e.Message.Text == "!chat on")
                        {
                            Core.WriteLineColoured(3, 2, e.User.ToString() + " [CMD] " + e.Message.Text);

                            e.Channel.SendMessage("Talking is my primary function.");
                            ChatOn = true;
                        }

                        // AI Chat Off
                        if (e.Message.Text == "!chat off")
                        {
                            Core.WriteLineColoured(3, 2, e.User.ToString() + " [CMD] " + e.Message.Text);

                            e.Channel.SendMessage("Talking is silenced.");
                            ChatOn = false;
                        }

                        // AI Math
                        if (e.Message.Text.Contains("!math "))
                        {
                            Core.WriteLineColoured(3, 2, e.User.ToString() + " [CMD] " + e.Message.Text);
                            e.Channel.SendMessage("Math Expression Evaluation:");

                            string cmd = e.Message.RawText.Replace("!math ", "");
                            e.Channel.SendMessage(NCalc.NCalcInput(cmd));
                        }
                        #endregion
                    }
                }
                else
                {
                    // AI Chat
                    if (e.Message.IsAuthor)
                    {
                        Console.WriteLine("[BOT] " + e.Message.Text);
                        // do nothing
                    }
                    else
                    {
                        Console.WriteLine(e.User.ToString() + "[CHAT] " + e.Message.Text);

                        if (ChatOn == true)
                        {
                            e.Channel.SendMessage(AIML.AIMLInput(e.Message.Text));
                        }
                        // do nothing
                    }
                    // NCalc
                }

                /*
                foreach (Role UserRole in e.User.Roles)
                {
                    Console.WriteLine(UserRole);
                }
                */
                #endregion
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
