using System.IO;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WarBot
{
    public class WarBotJson
    {
        //TODO: Fix dis crap and finish stats
        public static JObject js = JObject.Parse(ReadJson());

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
    }
}
