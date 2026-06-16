using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManagement
{
    public static class GameSceneManager
    {
        private const string gameplayScene = "HubRoomScene";

        public static void EnterGameplayScene()
        {
            GameManager.Instance.CleanUpWhenSceneChange();
            SceneManager.LoadScene(gameplayScene);
        }
    }
}