using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameManagement;

namespace MainMenu
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;

        [SerializeField] private Button newGame;
        [SerializeField] private Button continueGame;
        [SerializeField] private Button settings;
        [SerializeField] private Button exitGame;

        void AssignButton()
        {
            newGame.onClick.AddListener(NewGame);
            newGame.GetComponentInChildren<TextMeshProUGUI>().text = "New Game";
            continueGame.onClick.AddListener(ContinueGame);
            continueGame.GetComponentInChildren<TextMeshProUGUI>().text = "Continue";
            settings.onClick.AddListener(Settings);
            settings.GetComponentInChildren<TextMeshProUGUI>().text = "Settings";
            exitGame.onClick.AddListener(ExitGame);
            exitGame.GetComponentInChildren<TextMeshProUGUI>().text = "Exit";
        }

        private void Start()
        {
            AssignButton();
            gameManager = GameManager.Instance;
        }

        private void NewGame()
        {
            gameManager.NewGame();
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