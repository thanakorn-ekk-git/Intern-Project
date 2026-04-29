using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManagement
{
    public class GameSceneManager : MonoBehaviour
    {
        [SerializeField] private string gameplayScene = "HubRoomScene";

        public void EnterGameplayScene()
        {
            SceneManager.LoadScene(gameplayScene);
        }
    }
}