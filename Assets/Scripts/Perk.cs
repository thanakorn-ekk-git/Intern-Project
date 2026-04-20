using UnityEngine;

public class Perk
{
    public PerkData Data => data;
    PerkData data;

    public readonly int UUID;

    public Perk(PerkData data )
    {
        this.data = data;
        UUID = Random.Range(001, 100);
    }
}
