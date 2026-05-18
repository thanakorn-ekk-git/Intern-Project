using Newtonsoft.Json;

namespace Data 
{
    [JsonObject]
    public class CharacterGameData
    {
        [JsonProperty] private PlayerGameData player = new PlayerGameData();
        [JsonProperty] private EnemyGameData enemy = new EnemyGameData();

        public void Load() 
        { 
            player.Load();
        }
    }
}