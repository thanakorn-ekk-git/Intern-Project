using Services;
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
            var log = new System.Text.StringBuilder();
            foreach (var fileName in FileHandler.GetAllFileNames(global::Items.ItemGameData.Path, FileHandler.JsonExtension))
            {
                Debug.Log(fileName);
                FileHandler.LoadItemJson(fileName, out var item);
                log.AppendLine($"Loaded item ID {item.ID} at {fileName}");
                items.Add(item.ID, item);
            }
            Debug.Log(log.ToString());
            Debug.Log("Load item data completed");

        }

        public bool TryGetCharacter(string id, out Character.CharacterGameData character) => charData.TryGetValue(id, out character);

        public void LoadCharacterGameData()
        {
            charData = new();
            var log = new System.Text.StringBuilder();
            foreach (var fileName in FileHandler.GetAllFileNames(global::Character.CharacterGameData.Path, FileHandler.JsonExtension))
            {
                //Debug.Log(fileName);
                FileHandler.LoadCharacterJson(fileName, out var character);
                log.AppendLine($"Loaded character ID {character.ID} at {fileName}");
                charData.Add(character.ID, character);
            }
            Debug.Log(log.ToString());
            Debug.Log("Load character data completed");
        }
    }
}