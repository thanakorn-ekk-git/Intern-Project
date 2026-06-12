using UnityEngine;

[System.Serializable]
public class GameConfigs
{
    [SerializeField] private ProjectileByTag projectiles;
    public ProjectileByTag Projectiles => projectiles;
}
