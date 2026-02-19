public class NPC : IBattleSystem
{
    public string Name => TypeOfFoe;
    public string TypeOfFoe { get; set; } = string.Empty;
    public double HP { get; set; }
    public double Mana { get; set; }
    public double XPWhenDefeated { get; set; }
    public double BaseDamage { get; set; }
    public bool SpecialAttack { get; set; }
    public List<string> DropTable = new List<string>();

    public bool IsAlive => HP > 0;

    public void TakeDamage(double amount)
    {
        HP = Math.Max(0, HP - amount);
    }

    public double DealDamage(Random rng)
    {
        var rolledDamage = rng.Next(1, 101);

        if (rolledDamage <= 15)
        {
            return 0;
        }

        return Math.Round(BaseDamage, 1);
    }
}