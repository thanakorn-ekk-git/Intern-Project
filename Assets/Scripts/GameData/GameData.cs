using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace GameData
{
    public class GameData
    {
        public static GameData Instance => GameManagement.GameManager.Instance.GameData;

        private Dictionary<string, Items.ItemGameData> items;
        private Dictionary<string, Character.CharacterGameData> charData;

        public string GameDataPath => Path.Combine(Application.dataPath, "GameData");

        public bool TryGetItem(string id, out Items.ItemGameData item) => items.TryGetValue(id, out item);

        public void LoadItemGameData()
        {
            items = new();
            foreach (var fileName in Services.FileHandler.GetAllFileNames(global::Items.ItemGameData.Path))
            {
                Services.FileHandler.LoadItemJson(fileName, out var item);
                items.Add(item.ID, item);
            }
        }

        public bool TryGetCharacter(string id, out Character.CharacterGameData character) => charData.TryGetValue(id, out character);

        public void LoadCharacterGameData()
        {
            charData = new();
            foreach (var fileName in Services.FileHandler.GetAllFileNames(global::Character.CharacterGameData.Path))
            {
                Services.FileHandler.LoadCharacterJson(fileName, out var character);
                charData.Add(character.ID, character);
            }
        }
    }
}