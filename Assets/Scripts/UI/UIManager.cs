using MainMenu;
using Perk.UI;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance => GameManagement.GameManager.Instance.UIManager;

        private GameplayUI gameplayUI;
        private MainMenuUI mainMenuUI;
        [SerializeField] private PerkMenuUI perkMenuUI;

        private void Start()
        {
            OpenPerkMenu();
        }
        public void OpenPerkMenu()
        {
            perkMenuUI.Setup();
        }
    }
}
