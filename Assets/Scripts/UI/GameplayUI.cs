using TMPro;
using UnityEngine;

namespace UI
{
    public class GameplayUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI heroNameUI, curLevelUI;

        public string heroName { get; private set; } = string.Empty;
        public string curLevel { get; private set; }

        public void UpdateUI(Data.PlayerGameData.PlayerLevel level)
        {
            heroNameUI.text = heroName;
            curLevelUI.text = level.ToString();
        }
    }
}