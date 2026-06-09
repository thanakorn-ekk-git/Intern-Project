using GameManagement;
using Player;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Perk.UI
{
    public class PerkMenuUI : MonoBehaviour
    {
        [SerializeField] private PerkButtonUI perkButtonPrefab;
        [SerializeField] private RectTransform buttonArea;

        [Header("Detail")]
        [SerializeField] private TextMeshProUGUI perkName, description, perkStats, unlockPerkTxt;
        [SerializeField] private Image bigImage;
        [SerializeField] private Button unlockPerkBtn;

        private List<PerkButtonUI> spawnedButtons = new List<PerkButtonUI>();
        private PerkData selectedData;

        private PlayerController player;
        public void Setup()
        {
            foreach (var button in spawnedButtons)
            {
                Destroy(button.gameObject);
            }
            spawnedButtons.Clear();

            var allPerks = GameData.GameData.Instance.GetAllPerkData();

            foreach (var data in allPerks)
            {
                GameObject perkButton = Instantiate(perkButtonPrefab.gameObject, buttonArea);
                if (perkButton.TryGetComponent<PerkButtonUI>(out var scriptPerkButton))
                {
                    spawnedButtons.Add(scriptPerkButton);
                }
            }

            if (GameManager.Instance.Player.TryGetComponent<PlayerController>(out var playerController))
            {
                this.player = playerController;
            }

        }

        public void Unlock(PerkData data)
        {
            player.PerkManager.TryUnlockPerk(data.Name);
        }
        public void Select(PerkData data)
        {
            selectedData = data;
            perkName.text = data.Name;
            description.text = data.Description;
            
            bigImage.sprite = Resources.Load<Sprite>(data.ImagePath);

            Debug.Log(data.Name);
            bool isUnlocked = player.PerkManager.PerkExist(data.Name, out Perk outPerk);
            Debug.Log(outPerk); // out -> null

            perkStats.text = outPerk.Executor.GetDebugStatString();

            if (isUnlocked)
            {

                if (unlockPerkBtn != null)
                {
                    unlockPerkBtn.GetComponent<Image>().color = Color.black;
                    unlockPerkTxt.text = data.Name + "is unlocked";
                }
            }
            else if (!isUnlocked)
            {
                if (unlockPerkBtn != null)
                {
                    unlockPerkBtn.GetComponent<Image>().color = Color.white;
                    unlockPerkTxt.text = "Unlock" + data.Name;
                }
            }
        }
    }
}