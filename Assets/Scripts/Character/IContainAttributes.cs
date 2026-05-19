namespace Character
{
    public interface IContainAttributes
    {
        int MaxHealth { get; }
        int Mana { get; }
        int AtkDamage { get; }
        int Strength { get; }
        int Dexterity { get; }
        int Defense { get; }
        int Intelligence { get; }
    }
    public interface IAttackable
    {
        int AtkDamage { get; }
        int Strength { get; }
    }
    public interface IDefendable
    {
        int Defense { get; }
    }
}
