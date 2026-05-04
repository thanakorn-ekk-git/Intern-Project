using UnityEngine;

namespace GameManagement
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [SerializeField] private GameSceneManager sceneManager;

        private void Awake()
        {
            Instance ??= this;
            if (this != Instance)
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
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
    }
}