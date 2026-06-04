using UnityEngine;

namespace Perk.Testing
{
    public class PerkSystemTester : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                bool success = PerkManager.Instance.TryUnlockPerk("Blood Pump");

                var tmpPerkTree = PerkManager.Instance.GetPlayerPerkTree();

                if (success && tmpPerkTree.PerkExist("Blood Pump", out Perk perk))
                {
                    if (perk.Excutor != null)
                    {
                        perk.Excutor.OnUnlocked();
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                var tmpPerkTree = PerkManager.Instance.GetPlayerPerkTree();

                if (tmpPerkTree.PerkExist("Blood Pump", out Perk perk))
                {
                    if (perk.Excutor != null)
                    {
                        perk.Excutor.OnActive();
                    }
                    else
                    {
                        Debug.LogError("Blood Pump has invalid executor!");
                    }
                }
                else
                {
                    Debug.LogError("Blood Pump is not unlocked!");
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                var tmpPerkTree = PerkManager.Instance.GetPlayerPerkTree();
                Debug.Log(tmpPerkTree.WhatPerkIsUnlocked());
            }
        }


    }
}