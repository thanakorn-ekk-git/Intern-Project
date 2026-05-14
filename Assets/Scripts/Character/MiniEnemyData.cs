using UnityEngine;
using Newtonsoft.Json;

namespace Data
{
    [JsonObject]
    public class MiniEnemyData : EnemyData
    {
        [JsonProperty] private int hordeSize = 10;
    }
}