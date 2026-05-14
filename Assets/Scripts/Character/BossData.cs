using Data;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Data
{
    [JsonObject]
    public class BossData : EnemyData
    {
        [JsonProperty] private List<BossSkill> skills = new List<BossSkill>();
        [JsonProperty] private string activeArea = "boss_room";
        [JsonProperty] private int phase = 1;
        [JsonProperty] private float rageThreshold = 0.3f;

        [JsonObject]
        public class BossSkill
        {
            [JsonProperty] private float cooldown;
            [JsonProperty] private float damageMultiplier;
            [JsonProperty] private float range;
            [JsonProperty] private float areaOfEffect;
        }
    }
}