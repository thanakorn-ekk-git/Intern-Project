using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button newGame;
        [SerializeField] private Button continueGame;
        [SerializeField] private Button settings;
        [SerializeField] private Button exitGame;

        void AssignButton()
        {
            newGame.onClick.AddListener(NewGame);
            continueGame.onClick.AddListener(ContinueGame);
            settings.onClick.AddListener(Settings);
            exitGame.onClick.AddListener(ExitGame);
        }

        private void Start()
        {
            AssignButton();
        }

        private void NewGame()
        {
            // TODO : Implement new game
        }
        private void ContinueGame()
        {
            // TODO : Implement continue game 
        }
        private void Settings()
        {
            // TODO : Implement settings menu
        }
        private void ExitGame()
        {
            Application.Quit();
        }
    }
}