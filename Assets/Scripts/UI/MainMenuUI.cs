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

        [SerializeField] private TextMeshProUGUI newGameTxt;
        [SerializeField] private TextMeshProUGUI continueGameTxt;
        [SerializeField] private TextMeshProUGUI settingsTxt;
        [SerializeField] private TextMeshProUGUI exitGameTxt;

        void AssignButton()
        {
            newGame.onClick.AddListener(NewGame);
            newGameTxt.text = "New Game";
            continueGame.onClick.AddListener(ContinueGame);
            continueGameTxt.text = "Continue";
            settings.onClick.AddListener(Settings);
            settingsTxt.text = "Settings";
            exitGame.onClick.AddListener(ExitGame);
            exitGameTxt.text = "Exit";
        }

        private void Start()
        {
            AssignButton();
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