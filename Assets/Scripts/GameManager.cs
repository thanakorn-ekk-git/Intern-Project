using Character;
using Player;
using Services;
using UnityEngine;

namespace GameManagement
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField] private GameConfigs gameConfigs;
        public GameConfigs GameConfigs => gameConfigs;
        public GameData.GameData GameData { get; private set; }
        public PlayerData PlayerData { get; private set; }

        public UI.UIManager UIManager { get; private set; }
        public EnemyPrefabManager EnemyPrefabManager { get; private set; }

        private CharacterGameData characterData;

        public PlayerController Player
        {
            get
            {
                if (player == null)
                {
                    player = FindFirstObjectByType<PlayerController>();
                }
                return player;
            }
        }
        private PlayerController player;

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
            UIManager = GetComponent<UI.UIManager>();

            LoadGameData();
        }

        private void LoadGameData()
        {
            GameData = new GameData.GameData();
            GameData.LoadItemGameData();
            GameData.LoadCharacterGameData();
            GameData.LoadPerkData();
        }

        public void NewGame(bool isTesting = false)
        {
            PlayerData = new();
            if (!isTesting)
                GameSceneManager.EnterGameplayScene();
        }
        public void LoadGame()
        {
            PlayerData = FileHandler.LoadSaveData();
            GameSceneManager.EnterGameplayScene();
            OnGameLoaded();
        }
        public void SaveGame()
        {
            FileHandler.Save(PlayerData);
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

        public void OnGameLoaded()
        {

        }

        public void CleanUpWhenSceneChange()
        {
            player = null;
        }
    }
}