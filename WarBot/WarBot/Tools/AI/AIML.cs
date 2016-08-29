using AIMLbot;

namespace WarBot
{
    public class AIML
    {
        public static Bot myBot = new Bot();
        public static User myUser = new User(Program.DiscordUser, myBot);

        public static void LoadAIMLFiles()
        {
            myBot.loadSettings();
            myBot.isAcceptingUserInput = false;
            myBot.loadAIMLFromFiles();
            myBot.isAcceptingUserInput = true;
        }

        public static string AIMLInput(string input)
        {
            Request r = new Request(input, myUser, myBot);
            Result res = myBot.Chat(r);
            return res.Output;
        }
    }
}
