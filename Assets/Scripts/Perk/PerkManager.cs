using UnityEngine;

namespace Perk
{
    public class PerkManager : MonoBehaviour
    {
        public static PerkManager Instance => GameManagement.GameManager.Instance.PerkManager;

        private PerkTree perkTree = new();

        public string PerkNameToUnlock => perkNameToUnlock;
        [SerializeField] private string perkNameToUnlock; 

        private void Awake()
        {
            Debug.Log("PerkManager Awake");
        }
        public bool TryUnlockPerk(string perkName)
        {
            if (perkTree.PerkExist(perkName, out Perk outPerk))
            {
                Debug.Log($"{perkName} is already unlocked!");
                return false;
            }

            if (GameData.GameData.Instance.TryGetPerk(perkName, out PerkData outData))
            {
                Perk newPerk = new Perk(outData);
                newPerk.Unlock();

                PerkExcutor excutor = BindExcutor(perkName);

                if(excutor != null)
                {
                    newPerk.SetExcutor(excutor);
                    newPerk.Excutor.OnUnlocked();
                }

                perkTree.ActivatePerk(newPerk);
                return true;
            }
            Debug.LogWarning($"{perkName} is invalid");
            return false;
        }

        private PerkExcutor BindExcutor(string perkName)
        {
            switch (perkName) 
            {
                case "Ashen Armor":
                    return gameObject.AddComponent<AshenArmorExcute>();
                case "Blood Pump":
                    return gameObject.AddComponent<BloodPumpExcute>();
                case "Blood Recharge":
                    return gameObject.AddComponent<BloodRechargeExcute>();
                case "Echo Blow":
                    return gameObject.AddComponent<EchoBlowExcute>();
                case "Fire Dash":
                    return gameObject.AddComponent<FireDashExcute>();
                default: Debug.LogWarning($"No executor found for perk: {perkName}");
                    return null;
            }
        }

        public bool TryEnhancePerk(string perkName)
        {
            if (perkTree.PerkExist(perkName, out Perk perk))
            {
                if (perk.Excutor != null)
                {
                    if (perk.Data.Levels.Count >= 2)
                    {
                        if(perk.CurrentLevel < perk.Data.Levels.Count)
                        {
                            perk.LevelUp();
                            perk.Excutor.OnEnhance();
                            return true;
                        }
                        Debug.LogWarning($"{perkName} is already at max level!");
                        return false;
                    }
                    else
                    {
                        Debug.LogWarning($"{perkName} can not be enhanced!");
                        return false;
                    }
                }
                else
                {
                    Debug.LogWarning($"{perkName} has invalid executor!");
                    return false;
                }
            }
            else
            {
                Debug.LogWarning($"{perkName} is not unlocked!");
                return false;
            }
        }

        public PerkTree GetPlayerPerkTree() => perkTree;
    }
}