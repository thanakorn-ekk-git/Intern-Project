using Newtonsoft.Json;
using System.IO;
using System.Text;
using Character;
using UnityEngine;

namespace SaveGame
{
    public static class JsonSaveHandler
    {
        public static void JsonSave(string fullFilePath, PlayerData player)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            using (StreamWriter stream = new StreamWriter(fullFilePath))
            {
                using (JsonWriter writer = new JsonTextWriter(stream))
                {
                    player.Save();
                    serializer.Serialize(writer, player);
                }
            }
        }

        public static bool JsonLoad(string fullFilePath, out PlayerData playerData)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader stream = new StreamReader(fullFilePath))
            {
                using (JsonReader reader = new JsonTextReader(stream))
                {
                    var readed = serializer.Deserialize(stream, typeof(PlayerData));
                    playerData = readed as PlayerData;
                    playerData.Load();
                }
            }
            return true;
            // TODO : pull saved data from persistent data path and deserialize game data
            // TODO : apply loaded game setting
            // TODO : apply loaded data to player data (player name, level, health, status, inventory, etc.)
        }
    }
}