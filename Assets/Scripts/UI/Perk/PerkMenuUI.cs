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
        [SerializeField] private GameObject perkButtonPrefab;
        [SerializeField] private Transform buttonArea;

        [Header("Detail")]
        [SerializeField] private GameObject perkName, bigImage, description, perkStats, unlockPerkBtn, unlockPerkTxt;

        private List<GameObject> spawnedButtons = new List<GameObject>();
        private PerkData selectedData;

        public void Setup()
        {
            foreach(var button in spawnedButtons)
            {
                Destroy(button.gameObject);
            }
            spawnedButtons.Clear();

            var allPerks = GameData.GameData.Instance.GetAllPerkData();

            foreach (var data in allPerks)
            {
                GameObject newButton = Instantiate(perkButtonPrefab, buttonArea);
                spawnedButtons.Add(newButton);

                if (newButton.TryGetComponent<PerkButtonUI>(out var btnScript))
                {
                    btnScript.Setup(data, this);
                }
            }

        }

        public void Unlock(PerkData data)
        {
            if (GameManager.Instance.Player.TryGetComponent<PlayerController>(out var player))
            {
                bool success = player.PerkManager.TryUnlockPerk(data.Name);
            }
        }
        public void Select(PerkData data)
        {
            selectedData = data;
            if (perkName != null)
            {
                perkName.GetComponent<TextMeshProUGUI>().text = data.Name;
            }
            if (description != null)
            {
                description.GetComponent<TextMeshProUGUI>().text = data.Description;
            }
            if (bigImage != null && bigImage.TryGetComponent<Image>(out var img))
            {
                img.sprite = Resources.Load<Sprite>(data.ImagePath);
            }

            if (GameManager.Instance.Player.TryGetComponent<PlayerController>(out var player))
            {
                Debug.Log(data.Name);
                bool isUnlocked = player.PerkManager.PerkExist(data.Name, out Perk outPerk);
                Debug.Log(outPerk); // out -> null

                if (perkStats != null)
                {
                    perkStats.GetComponent<TextMeshProUGUI>().text = outPerk.Executor.GetStatValue();
                }
                if (isUnlocked)
                {

                    if (unlockPerkBtn != null)
                    {
                        unlockPerkBtn.GetComponent<Image>().color = Color.black;
                        unlockPerkTxt.GetComponent<TextMeshProUGUI>().text = data.Name + "is unlocked";
                    }
                }
                else if (!isUnlocked)
                {
                    if (unlockPerkBtn != null)
                    {
                        unlockPerkBtn.GetComponent<Image>().color = Color.white;
                        unlockPerkTxt.GetComponent<TextMeshProUGUI>().text = "Unlock" + data.Name;
                    }
                }
            }
        }
    }
}