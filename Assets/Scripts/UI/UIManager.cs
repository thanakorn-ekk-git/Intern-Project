using MainMenu;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        private GameplayUI gameplayUI;
        private MainMenuUI mainMenuUI;

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
    }
}
