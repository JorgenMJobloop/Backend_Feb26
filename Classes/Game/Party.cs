public class Party
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
}