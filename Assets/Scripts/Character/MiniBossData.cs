using UnityEngine;
using Newtonsoft.Json;

namespace Data
{
    [JsonObject]
    public class MiniBossData : EnemyData
    {
        [JsonProperty] private float physicalSize = 1.5f;
    }
}