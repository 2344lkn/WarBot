using System;
using System.IO;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WarBot
{
    // TODO: Clean up WarBotJso & Optimize
    public class WarBotJson
    {
        public static int CommandsRan = 0;
        public static string TotalTimeOnline = "";
        public static int MathSolved = 0;
        public static int AIChatMsgs = 0;

        public static JObject js = JObject.Parse(ReadJson());

        public static void SetWarBotStats()
        {
            CommandsRan = (int)js["WarBot"]["CommandsRan"];
            TotalTimeOnline = (string)js["WarBot"]["TotalTimeOnline"];
            MathSolved = (int)js["WarBot"]["MathSolved"];
            AIChatMsgs = (int)js["WarBot"]["AIChatMsgs"];
        }

        private static string ReadJson()
        {
            using (StreamReader file = File.OpenText(@"WarBot.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
                return o2.ToString();
            }
        }

        #region Json Queries
        public static string QueryToken()
        {
            return (string)js["WarBot"]["BotToken"];
        }
        #endregion

        #region Json Inserts
        public static void UpdateWarBotStats()
        {
            string json = File.ReadAllText("WarBot.json");

            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            jsonObj["WarBot"]["CommandsRan"] = CommandsRan;
            jsonObj["WarBot"]["MathSolved"] = MathSolved;
            jsonObj["WarBot"]["AIChatMsgs"] = AIChatMsgs;
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText("WarBot.json", output);
        }
        #endregion
    }
}
