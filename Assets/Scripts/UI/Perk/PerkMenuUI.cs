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
        [SerializeField] private Image unlockPerkBtnImg;

        private List<PerkButtonUI> spawnedButtons = new List<PerkButtonUI>();
        private PerkData selectedData;

        private PlayerController player;
        public void Setup()
        {
            this.player = GameManager.Instance.Player;

            foreach (var button in spawnedButtons)
            {
                Destroy(button.gameObject);
            }
            spawnedButtons.Clear();

            var allPerks = GameData.GameData.Instance.GetAllPerkData();

            foreach (var data in allPerks)
            {
                var perkButton = Instantiate(perkButtonPrefab, buttonArea);
                spawnedButtons.Add(perkButton);
                perkButton.Setup(data, this);
            }
        }
        public void Unlock(PerkData data)
        {
            player.PerkManager.TryUnlockPerk(data);
            Select(data);
        }
        public void Select(PerkData data)
        {
            selectedData = data;
            perkName.text = data.Name;
            description.text = data.Description;
            
            bigImage.sprite = Resources.Load<Sprite>(data.ImagePath);


            perkStats.text = data.GetDebugStatString();

            unlockPerkBtn.onClick.RemoveAllListeners();
            unlockPerkBtn.onClick.AddListener(() => Unlock(selectedData)); 

            bool isUnlocked = player.PerkManager.Unlocked.ContainsKey(data.ID);

            if (isUnlocked)
            {

                unlockPerkBtnImg.color = Color.black;
                unlockPerkTxt.text = data.Name + "is unlocked";
                unlockPerkBtn.gameObject.SetActive(false);
            }
            else
            {
                unlockPerkBtnImg.color = Color.white;
                unlockPerkTxt.text = "Unlock" + data.Name;
                unlockPerkBtn.gameObject.SetActive(true);
            }
        }
    }
}