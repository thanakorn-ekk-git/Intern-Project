using Character;
using Services;
using UnityEngine;

namespace GameManagement
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;


        private FileHandler fileHandler;
        public GameData.GameData GameData { get; private set; }
        public UI.UIManager UIManager { get; private set; }
        public EnemyPrefabManager EnemyPrefabManager { get; private set; }
        public Perk.PerkManager PerkManager { get; private set; } 

        private CharacterGameData characterData;
        private GameSceneManager sceneManager;

        public LayerMask LayerEntity => entity;
        public LayerMask LayerGround => ground;
        public LayerMask LayerEntityAndGround => entityAndGround;
        [SerializeField] private LayerMask ground, entity, entityAndGround;

        private void Awake()
        {
            Instance ??= this;
            if (this != Instance)
            {
                DestroyImmediate(gameObject);
                return;
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
            PerkManager = GetComponent<Perk.PerkManager>();
            LoadGameData();
        }

        private void LoadGameData()
        {
            GameData = new GameData.GameData();
            GameData.LoadItemGameData();
            GameData.LoadCharacterGameData();
            GameData.LoadPerkData();
        }

        public void NewGame()
        {
            // TODO : load game scene with new player data
            sceneManager.EnterGameplayScene();
            // TODO : initialize new player data and game state
        }
        public void LoadGame()
        {
            // TODO : load game scene where player saved with saved player data
            sceneManager.EnterGameplayScene();
            fileHandler.LoadSaveData();
        }
        public void SaveGame()
        {
            // TODO : save player and game state data(current level, player stats)
        }
        public void RestartGame()
        {
            // TODO : reload current game scene with lastest saved player data
        }
        public void NextLevel()
        {
            // TODO : load next level scene with current player data
        }
        public void ExitGame()
        {
            // TODO : add pop-up confirmation dialog before quitting
            Application.Quit();
        }
        public void MainMenu()
        {
            // TODO : load main menu scene
        }
        public void PauseGame()
        {
            // TODO : pause time and show pause menu
        }
        public void ResumeGame()
        {
            // TODO : resume time and hide pause menu
        }

        public void LoadGameData(string loadResult, CharacterGameData charData)
        {
            characterData.Load(charData);
        }
        public void LoadSaveData(CharacterGameData charData)
        {

        }
    }
}