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
        public const string Version = "1.1.7";

        private static bool ChatOn = false;
        public static string DiscordUser = "2344lkn";
        public DateTime startTime = DateTime.Now;

        private DiscordClient _bot;

        private void Start(string[] args)
        {
            Console.Title = $"{AppName} {Version}";
            Core.ConsoleIntro();

            // Load Stats from WarBotJson
            WarBotJson.SetWarBotStats();

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
                            WarBotJson.CommandsRan++;
                        }

                        // About Cmd
                        if (e.Message.Text == "!about")
                        {
                            Core.WriteLineColoured(3, 2, e.User.ToString() + " [CMD] " + e.Message.Text);

                            e.Channel.SendMessage(Core.AboutCmd());
                            WarBotJson.CommandsRan++;
                        }

                        // WarBot Stats Cmd
                        if (e.Message.Text == "!stats")
                        {
                            Core.WriteLineColoured(3, 2, e.User.ToString() + " [CMD] " + e.Message.Text);
                            // TODO: Add total time
                            e.Channel.SendMessage("```Commands Executed: " + WarBotJson.CommandsRan + "\r\n" +
                                //"Total Time Online: " + WarBotJson.TotalTimeOnline + "\r\n" +
                                "Math Problems Solved: " + WarBotJson.MathSolved + "\r\n" +
                                "AI Chat Messages: " + WarBotJson.AIChatMsgs + "```");

                            WarBotJson.CommandsRan++;
                        }

                        // Uptime
                        if (e.Message.Text == "!uptime" || e.Message.Text == "!s")
                        {
                            Core.WriteLineColoured(3, 2, e.User.ToString() + " [CMD] " + e.Message.Text);

                            var delta = DateTime.Now - startTime;
                            e.Channel.SendMessage((delta.Days.ToString("N0") + " days, " + delta.Hours.ToString("N0") +
                                " hours and " + delta.Minutes.ToString("N0") + " minutes"));

                            WarBotJson.CommandsRan++;
                        }

                        // Quit Cmd
                        if (e.Message.Text == "!exit" || e.Message.Text == "!quit" || e.Message.Text == "!disc")
                        {
                            Core.WriteLineColoured(3, 2, e.User.ToString() + " [CMD] " + e.Message.Text);

                            if (e.Message.User.Id.ToString() == "202128606481219585")
                            {
                                WarBotJson.UpdateWarBotStats();

                                Task.Delay(500); // Delay the bot so we can update WarBotJson

                                _bot.Disconnect();
                            }
                            else
                            {
                                // Do Nothing
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
                            WarBotJson.CommandsRan++;
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
                            WarBotJson.CommandsRan++;
                        }
                        #endregion

                        #region AI Commands
                        // AI Chat On
                        if (e.Message.Text == "!chat on")
                        {
                            Core.WriteLineColoured(3, 2, e.User.ToString() + " [CMD] " + e.Message.Text);

                            e.Channel.SendMessage("Talking is my primary function.");
                            ChatOn = true;
                            WarBotJson.CommandsRan++;
                        }

                        // AI Chat Off
                        if (e.Message.Text == "!chat off")
                        {
                            Core.WriteLineColoured(3, 2, e.User.ToString() + " [CMD] " + e.Message.Text);

                            e.Channel.SendMessage("Talking is silenced.");
                            ChatOn = false;
                            WarBotJson.CommandsRan++;
                        }

                        // AI Math
                        if (e.Message.Text.Contains("!math "))
                        {
                            Core.WriteLineColoured(3, 2, e.User.ToString() + " [CMD] " + e.Message.Text);
                            e.Channel.SendMessage("Math Expression Evaluation:");

                            string cmd = e.Message.RawText.Replace("!math ", "");
                            e.Channel.SendMessage(NCalc.NCalcInput(cmd));
                            WarBotJson.MathSolved++;
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
                            WarBotJson.AIChatMsgs++;
                        }
                        // do nothing
                    }
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
                        await _bot.Connect(WarBotJson.QueryToken());

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
