using Newtonsoft.Json;

namespace Data 
{
    [JsonObject]
    public class CharacterGameData
    {
        [JsonProperty] private PlayerGameData player = new PlayerGameData();
        [JsonProperty] private EnemyGameData enemy = new EnemyGameData();

        public void Load(CharacterGameData characterData) 
        { 
            player.Load(characterData.player);
            enemy.Load(characterData.enemy);
        }
    }
}