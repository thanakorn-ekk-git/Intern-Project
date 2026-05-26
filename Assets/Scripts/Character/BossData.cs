using Data;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Data
{
    [JsonObject]
    public class BossData : EnemyGameData
    {
        [JsonProperty] private List<SkillData> skills = new List<SkillData>();
        [JsonProperty] private string activeArea = "boss_room";
        [JsonProperty] private int phase = 1;
        [JsonProperty] private float rageThreshold = 0.3f;
    }
}