using Newtonsoft.Json;
using UnityEngine;

public class SkillData
{
    [JsonProperty] private float cooldown;
    [JsonProperty] private float damageMultiplier;
    [JsonProperty] private float range;
    [JsonProperty] private float areaOfEffect;
}
