using Perk;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AOEByTag", menuName = "Config/AOEByTag")]
public class AOEByTag : ScriptableObject
{
    [SerializeField] private GameObject aoePrefab;

    [SerializeField] private Element[] elements;
    private Dictionary<Perk.Perk.Tag, AOE> tagToAOE;

    [System.Serializable]
    public class Element
    {
        [SerializeField] internal Perk.Perk.Tag tag;
        [SerializeField] internal AOE prefab;
    }

    public bool TryGetAOE(Perk.Perk.Tag tag, out AOE aoe)
    {
        if (tagToAOE == null)
        {
            tagToAOE = new();
            foreach (Element e in elements)
            {
                tagToAOE.Add(e.tag, e.prefab);
            }
        }
        return tagToAOE.TryGetValue(tag, out aoe);
    }
}