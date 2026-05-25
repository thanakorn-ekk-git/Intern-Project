using Data;
using Newtonsoft.Json;
using SaveGame;
using System.IO;
using UnityEngine;

namespace Services
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

        public static string[] GetAllFileNames(string directoryPath)
        {
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Debug.LogError(directoryPath + "is not found!");
                    return System.Array.Empty<string>();
                }

                string[] files = Directory.GetFiles(directoryPath);
                return files;
            }
            catch (IOException error)
            {
                Debug.LogError("Read directory fail => " + directoryPath + "\nWith error" + error);
                throw error;
            }
        }
        private static bool LoadGameData<T>(string filePath, out object obj)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    obj = null;
                    return false;
                }
                
                using (StreamReader fileReader = File.OpenText(filePath))
                {
                    JsonSerializer serializer = new();
                    obj = serializer.Deserialize(fileReader, typeof(T));

                    return true;
                }
            }
            catch (IOException error)
            {
                Debug.LogError(error);
                throw error;
            }
        }
        public static bool LoadItemJson(string filePath, out Items.ItemGameData item)
        {
            var result = LoadGameData<Items.ItemGameData>(filePath, out var obj);
            item = obj as Items.ItemGameData;
            return result;
        }

        public static bool LoadCharacterJson(string filePath, out Character.CharacterGameData character)
        {
            var result = LoadGameData<Character.CharacterGameData>(filePath, out var obj);
            character = obj as Character.CharacterGameData;
            return result;
        }
    }
}
