using UnityEngine;
using Newtonsoft.Json;
using GameManagement;

namespace Data 
{
    [JsonObject]
    public class CharacterData
    {
        [JsonProperty] private PlayerData player = new PlayerData();
        [JsonProperty] private EnemyData enemy = new EnemyData();

        public void Save()
        {

        }

        public void Load() 
        { 
            player.Load();
        }
    }
}