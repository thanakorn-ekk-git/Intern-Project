using Data;
using GameManagement;
using SaveGame;
using System.IO;
using UnityEngine;

namespace FileManagement
{
    public class FileHandler : MonoBehaviour
    {
        public const string SaveFolderName = "GameData";
        public const string SaveGameName = "CharacterSaveData";
        public const string SaveGameExtension = ".json";
        public const string SaveGameFullName = SaveGameName + SaveGameExtension;

        public void Save()
        {
            try
            {
                var folderPath = Path.Combine(Application.dataPath, SaveFolderName);
                var fullPath = Path.Combine(folderPath, SaveGameFullName);

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                if (Directory.Exists(fullPath))
                    Directory.Delete(fullPath);
                
                JsonSaveHandler.JsonSave(fullPath, new CharacterGameData());
            } 
            catch (IOException error)
            { 
                Debug.LogError(error);
                throw error;
            }
        }
        public void Load()
        {
            var result = string.Empty;

            try
            {
                var folderPath = Path.Combine(Application.dataPath, SaveFolderName);
                var fullPath = Path.Combine(folderPath, SaveGameFullName);

                if (File.Exists(fullPath))
                {
                    JsonSaveHandler.JsonLoad(fullPath, out var charData);
                    result = File.ReadAllText(fullPath);
                    GameManager.Instance.LoadCharacterData(charData);
                }
            }
            catch (IOException error)
            {
                Debug.LogError(error);
                throw error;
            }
            Debug.Log($"Loaded data: {result}");
        }
    }
}
