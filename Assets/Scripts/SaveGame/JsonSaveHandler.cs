using Character;
using Newtonsoft.Json;
using System.IO;

namespace SaveGame
{
    public static class JsonSaveHandler
    {
        public static void JsonSave(string fullFilePath, PlayerData data)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            using (StreamWriter stream = new StreamWriter(fullFilePath))
            {
                using (JsonWriter writer = new JsonTextWriter(stream))
                {
                    serializer.Serialize(writer, data);
                }
            }
        }

        public static bool JsonLoad(string fullFilePath, out PlayerData data)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader stream = new StreamReader(fullFilePath))
            {
                using (JsonReader reader = new JsonTextReader(stream))
                {
                    var readed = serializer.Deserialize(stream, typeof(PlayerData));
                    data = readed as PlayerData;
                }
            }
            return true;
        }
    }
}