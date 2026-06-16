using Perk;
using UnityEngine;

[System.Serializable]
public class GameConfigs
{
    [SerializeField] private ProjectileByTag projectiles;
    public ProjectileByTag Projectiles => projectiles;

    [SerializeField] private AOEByTag aoes;
    public AOEByTag AOES => aoes;

    [SerializeField] private ProjectileSpawner projectileSpawner;
    public ProjectileSpawner ProjectileSpawner => projectileSpawner;
    [SerializeField] private AOESpawner aoeSpawner; 
    public AOESpawner AOESpawner => aoeSpawner;
}
