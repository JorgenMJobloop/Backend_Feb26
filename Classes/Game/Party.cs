public enum PartyMember
{
    Warrior = 1,
    Mage = 2,
    Ranger = 3,
    Healer = 4,
    Tank = 5,
    Assasin = 6
}
public class Party : BattleSystem
{
    private readonly List<CharacterClass> _companions = new List<CharacterClass>();
    public IReadOnlyList<CharacterClass> Companions => _companions;

    public void Recruit(CharacterClass companion)
    {
        _companions.Add(companion);
    }

    public int BonusAccuracy => _companions.Count(companion => companion.Build == CharacterBuild.Ranger);
    public int BonusCrit => _companions.Count(c => c.Build == CharacterBuild.Warrior);
    public double BonusLootChance => _companions.Count(c => c.Build == CharacterBuild.Mage);
    public double BonusHealing => _companions.Count(c => c.Build == CharacterBuild.Healer);

    public override string Name { get; }

    public PartyMember Role { get; }
    public override int AttackSpeed { get; }

    public override int Accuracy { get; }

    public override int CritChance { get; }

    public override double BaseDamage { get; }


    public Party(string name, PartyMember role, double hp, double mana, int attackSpeed, int critChance) : base(hp, mana)
    {
        Name = name;
        Role = role;
        AttackSpeed = attackSpeed;
        CritChance = CritChance;
    }

}