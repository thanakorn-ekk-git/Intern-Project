using UnityEngine;

namespace SaveGame
{
    public static class JsonSaveHandler
    {
        public static void JsonSave()
        {
            // TODO : pull game setting to be serialized
            // TODO : pull player's data to be serialized (player name, level, health, status, inventory, etc.)
            // TODO : serialize game data and save to persistent data path
        }

        public static void JsonLoad()
        {
            // TODO : pull saved data from persistent data path and deserialize game data
            // TODO : apply loaded game setting
            // TODO : apply loaded data to player data (player name, level, health, status, inventory, etc.)
        }
    }
}