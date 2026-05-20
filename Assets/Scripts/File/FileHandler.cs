using Data;
using GameManagement;
using SaveGame;
using System.IO;
using UnityEngine;

namespace FileManagement
{
    public class FileHandler : MonoBehaviour
    {
        public const string GameDataFolderName = "GameData";
        public const string GameDataFileName = "main_data";
        public const string GameDataFullName = GameDataFolderName + GameDataFileName;

        public const string SaveGameName = "main_save";
        public const string SaveGameExtension = ".sav";
        public const string SaveGameFullName = SaveGameName + SaveGameExtension;

        public void Save()
        {
            try
            {
                var fullPath = Path.Combine(Application.persistentDataPath, SaveGameFullName);

                if (!Directory.Exists(Application.persistentDataPath))
                    Directory.CreateDirectory(Application.persistentDataPath);

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
        public void LoadSaveData()
        {
            var result = string.Empty;

            try
            {
                var fullPath = Path.Combine(Application.persistentDataPath, SaveGameFullName);

                if (File.Exists(fullPath))
                {
                    JsonSaveHandler.JsonLoad(fullPath, out var charData);
                    result = File.ReadAllText(fullPath);
                    GameManager.Instance.LoadSaveData(charData);
                }
            }
            catch (IOException error)
            {
                Debug.LogError(error);
                throw error;
            }
            Debug.Log($"Loaded data: {result}");
        }

        public bool LoadGameData( out CharacterGameData charData)
        {
            var Result = string.Empty;

            var fullPath = Path.Combine(Application.dataPath, GameDataFullName);

            if (File.Exists(fullPath))
            {
                JsonSaveHandler.JsonLoad(fullPath, out var CharData);
                Result = File.ReadAllText(fullPath);
                charData = CharData;
                return true;
            }
            else
            {
                charData = null;
                return false;
            }
        }
    }
}
