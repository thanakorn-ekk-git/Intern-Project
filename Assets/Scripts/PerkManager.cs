using System;
using System.Collections.Generic;
using UnityEngine;

namespace Perk
{
    public class PerkManager : MonoBehaviour
    {
        public static PerkManager Instance => GameManagement.GameManager.Instance.PerkManager;

        private PerkTree perkTree = new();

        public bool TryUnlockPerk(string perkName)
        {
            if (perkTree.PerkExist(perkName, out Perk outPerk))
            {
                Debug.Log($"{perkName} is already unlocked!");
                return false;
            }

            if (GameData.GameData.Instance.TryGetPerk(perkName, out PerkData outData))
            {
                Perk newPerk = new Perk();
                newPerk.isUnlocked = true;

                PerkExcutor excutor = BindExcutor(perkName);

                if(excutor != null)
                {
                    newPerk.SetExcutor(excutor);
                    newPerk.Excutor.OnUnlocked();
                }

                perkTree.ActivatePerk(newPerk);
                return true;
            }
            Debug.LogError($"{perkName} is invalid");
            return false;
        }

        private PerkExcutor BindExcutor(string perkName)
        {
            switch (perkName) 
            {
                case "Blood Pump":
                    return gameObject.AddComponent<BloodPumpExcute>();
                default: Debug.LogError($"No executor found for perk: {perkName}");
                    return null;
            }
        }
    }
}