public class Party
{
    private readonly List<CharacterClass> _companions = new List<CharacterClass>();
    public IReadOnlyList<CharacterClass> Companions => _companions;

    public void Recruit(CharacterClass companion)
    {
        _companions.Add(companion);
    }
}