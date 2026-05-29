using MainMenu;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance => GameManagement.GameManager.Instance.UIManager;

        private GameplayUI gameplayUI;
        private MainMenuUI mainMenuUI;
    }
}
