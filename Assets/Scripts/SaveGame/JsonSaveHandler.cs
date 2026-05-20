using Data;
using Newtonsoft.Json;
using System.IO;

namespace SaveGame
{
    public static class JsonSaveHandler
    {
        public static void JsonSave(string fullFilePath, CharacterGameData charData)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            using (StreamWriter stream = new StreamWriter(fullFilePath))
            {
                using (JsonWriter writer = new JsonTextWriter(stream))
                {
                    serializer.Serialize(writer, charData);
                }
            }
        }

        public static bool JsonLoad(string fullFilePath, out CharacterGameData charData)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader stream = new StreamReader(fullFilePath))
            {
                using (JsonReader reader = new JsonTextReader(stream))
                {
                    var readed = serializer.Deserialize(stream, typeof(CharacterGameData));
                    charData = readed as CharacterGameData;
                }
            }
            return true;
        }
    }
}