using Character;
using Newtonsoft.Json;
using SaveGame;
using System.IO;
using UnityEngine;
using System.Linq;

namespace Services
{
    public class FileHandler : MonoBehaviour
    {
        public const string GameDataFolderName = "GameData";
        public const string GameDataFileName = "main_data";
        public const string GameDataFullName = GameDataFolderName + GameDataFileName;

        public const string SaveGameName = "main_save";
        public const string SaveGameExtension = ".sav";
        public const string SaveGameFullName = SaveGameName + SaveGameExtension;

        public const string JsonExtension = ".json";

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
                    GameManagement.GameManager.Instance.LoadSaveData(charData);
                }
            }
            catch (IOException error)
            {
                Debug.LogError(error);
                throw error;
            }
            Debug.Log($"Loaded data: {result}");
        }

        public static string[] GetAllFileNames(string directoryPath, string extension)
        {

            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Debug.LogError(directoryPath + " is not found!");
                    return System.Array.Empty<string>();
                }

                string[] files = Directory.GetFiles(directoryPath);
                
                return files.Where(str=>Path.GetExtension(str)==extension).ToArray();
                
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
                obj = default;
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

        public static bool LoadCharacterJson(string filePath, out CharacterGameData character)
        {
            var result = LoadGameData<CharacterGameData>(filePath, out var obj);
            character = obj as CharacterGameData;
            return result;
        }

        public static bool LoadPerkJson(string filePath, out Perk.PerkData perk)
        {
            var result = LoadGameData<Perk.PerkData>(filePath, out var obj);
            perk = obj as Perk.PerkData;
            return result;
        }
    }
}
