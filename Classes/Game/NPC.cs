public class NPC
{
    public string TypeOfFoe { get; set; } = string.Empty;
    public double HP { get; set; }
    public double Mana { get; set; }
    public double XPWhenDefeated { get; set; }
    public double BaseDamage { get; set; }
    public bool SpecialAttack { get; set; }
    public List<string> DropTable = new List<string>();
}