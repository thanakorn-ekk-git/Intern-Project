using TMPro;
using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    public static GameplayUI Instance;
    [SerializeField] private TextMeshProUGUI heroNameUI, curLevelUI;

    public string heroName = string.Empty;
    public string curLevel;
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
    public void UpdateUI(Data.PlayerData.PlayerLevel level)
    {
        heroNameUI.text = heroName;
        curLevelUI.text = level.ToString();
    }
}
