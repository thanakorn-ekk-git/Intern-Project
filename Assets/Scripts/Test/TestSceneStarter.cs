using GameManagement;
using Player;
using UI;
using UnityEngine;

public class TestSceneStarter : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private PlayerController player;

    private void Awake()
    {
        if (gameManager == null)
            Debug.LogError("No GameManager");
        if (uiManager == null)
            Debug.LogError("No UIManger");
        if (player == null)
            Debug.LogError("No PlayerController");
    }
    private void Start()
    {
        GameManager.Instance.NewGame(isTesting: true);
    }
}
