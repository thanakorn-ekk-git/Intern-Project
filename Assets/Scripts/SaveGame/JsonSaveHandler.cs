using Data;
using Newtonsoft.Json;
using System.IO;

namespace SaveGame
{
    public static class JsonSaveHandler
    {
        public static void JsonSave(string fullFilePath, CharacterData charData)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            using (StreamWriter stream = new StreamWriter(fullFilePath))
            {
                using (JsonWriter writer = new JsonTextWriter(stream))
                {
                    charData.Save();
                    serializer.Serialize(writer, charData);
                }
            }
        }

        public static bool JsonLoad(string fullFilePath, out CharacterData charData)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader stream = new StreamReader(fullFilePath))
            {
                using (JsonReader reader = new JsonTextReader(stream))
                {
                    var readed = serializer.Deserialize(stream, typeof(CharacterData));
                    charData = readed as CharacterData;
                    charData.Load();
                }
            }
            return true;
        }
    }
}