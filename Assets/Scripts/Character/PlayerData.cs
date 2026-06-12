using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using Perk;
using System.Linq;

namespace Character
{
    [JsonObject]
    public class PlayerData
    {
        public string playerName { get; private set; } = "Hero";

        [JsonProperty] public (string perk, int level)[] UnlockedPerks = Array.Empty<(string, int)>();
        [JsonProperty] public string[] SlotedPerks = Array.Empty<string>();

        public void UpdateValue(PerkManager perkManager)
        {
            UnlockedPerks = perkManager.Unlocked.Select(x => (x.Key, x.Value.GetLevel().current)).ToArray();
            SlotedPerks = perkManager.Slot.Select(x => x == null ? string.Empty : x.Data.ID).ToArray();
        }
    }
}