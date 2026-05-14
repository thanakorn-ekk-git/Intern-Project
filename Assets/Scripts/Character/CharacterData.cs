using UnityEngine;
using Newtonsoft.Json;

namespace Data {
    [JsonObject]
    public class CharacterData
    {
        [JsonProperty] private PlayerData player = new PlayerData();
        [JsonProperty] private EnemyData enemy = new EnemyData();
    }


}