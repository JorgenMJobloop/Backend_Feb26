/// <summary>
/// A superclass containing abstract properties & methods regarding the improved battle engine (turn based)
/// </summary>
public abstract class BattleSystem : IBattleSystem
{
    // Abstract fields & properties, can be overwritten by other classes & sub-classes
    public abstract string Name { get; }
    public abstract int AttackSpeed { get; }
    public abstract int Accuracy { get; }
    public abstract int CritChance { get; }
    public abstract double BaseDamage { get; }

    public double HP { get; protected set; }
    public double MaxHP { get; protected set; }
    public double Mana { get; protected set; }
    public double MaxMana { get; protected set; }

    public bool IsCurrentlyDefending { get; set; }
    public bool IsAlive => HP > 0;

    protected BattleSystem(double hp, double mana)
    {
        MaxHP = hp;
        HP = hp;
        MaxMana = mana;
        Mana = mana;
    }

    public void TakeDamage(double amount)
    {
        if (amount <= 0)
        {
            return;
        }

        double finalDamageTaken = IsCurrentlyDefending ? amount * 0.6 : amount;
        HP = Math.Max(0, HP - finalDamageTaken);
    }

    public void Heal(double amount)
    {
        if (amount <= 0)
        {
            return;
        }
        HP = Math.Min(MaxHP, HP + amount);
    }

    public void SpendMana(double amount)
    {
        if (amount <= 0)
        {
            return;
        }
        Mana = Math.Max(0, Mana - amount);
    }

}