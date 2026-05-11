using Data;
using SaveGame;
using System.IO;
using UnityEngine;

namespace FileManagement
{
    public class FileHandler : MonoBehaviour
    {
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
                
                JsonSaveHandler.JsonSave(fullPath, new PlayerData());
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
                var fullPath = Path.Combine(Application.persistentDataPath, SaveGameFullName);

                if (File.Exists(fullPath))
                {
                    JsonSaveHandler.JsonLoad(fullPath, out var playerData);
                    result = File.ReadAllText(fullPath);
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
