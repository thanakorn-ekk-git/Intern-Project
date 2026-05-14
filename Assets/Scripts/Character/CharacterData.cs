using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Data {
    [JsonObject]
    public class CharacterData
    {
        [JsonProperty] private PlayerData player = new PlayerData();
        [JsonProperty] private List<EnemyData> enemy = new List<EnemyData>();
    }
}