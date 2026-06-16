using Perk;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileByTag", menuName = "Config/ProjectileByTag")]
public class ProjectileByTag : ScriptableObject
{
    [SerializeField] private Element[] elements;
    private Dictionary<Perk.Perk.Tag, Projectile> tagToProjectile;

    [System.Serializable]
    public class Element 
    {
        [SerializeField] internal Perk.Perk.Tag tag;
        [SerializeField] internal Projectile prefab;
    }

    public bool TryGetProjectile(Perk.Perk.Tag tag, out Projectile projectile)
    {
        if(tagToProjectile == null)
        {
            tagToProjectile = new();
            foreach(Element e in elements)
            {
                tagToProjectile.Add(e.tag, e.prefab);
            }
        }
        return tagToProjectile.TryGetValue(tag, out projectile);
    }
}