using Newtonsoft.Json;

namespace Data
{
    [JsonObject]
    public class PlayerGameData
    {
        [JsonProperty] private string name = "Hero";
        [JsonProperty] private PlayerLevel level = new PlayerLevel();
        [JsonProperty] private PlayerStats stats = new PlayerStats();

        public void Save()
        {
            // TODO : pull player's data to be serialized (player name, level, health, status, inventory, etc.)
        }

        public void Load()
        {
            GameplayUI gameplayUI  = GameplayUI.Instance;

            gameplayUI.heroName = name;
            gameplayUI.UpdateUI(level);
            // TODO : apply loaded data to player data (player name, level, health, status, inventory, etc.)
        }

        public override string ToString()
        {
            return $"{GetType()} {name} {level} {stats}";
        }

        [JsonObject]
        public class PlayerLevel 
        { 
            [JsonProperty] private int level = 1;
            [JsonProperty] private int exp = 0;

            public override string ToString()
            {
                return $"Level: {level}\nExp: {exp}";
            }
        }

        [JsonObject]
        public class PlayerStats
        {
            public int Health => health;
            [JsonProperty] private int health = 100;
            public int Mana => mana;
            [JsonProperty] private int mana = 50;
            public int AtkDamage => atkDamage;
            [JsonProperty] private int atkDamage = 0;
            public int Strength => strength;
            [JsonProperty] private int strength = 0;
            public int Dexterity => dexterity;
            [JsonProperty] private int dexterity = 0;
            public int Defence => defence;
            [JsonProperty] private int defence = 0;
            public int Intelligence => intelligence;
            [JsonProperty] private int intelligence = 0;


            public override string ToString()
            {
                return $"Health = {health}\nMana = {mana}\nAtkDamage = {atkDamage}\nStrength = {strength}\nDexterity = {dexterity}\nDefence = {defence}\nIntelligence = {intelligence}";
            }
        }
    }
}