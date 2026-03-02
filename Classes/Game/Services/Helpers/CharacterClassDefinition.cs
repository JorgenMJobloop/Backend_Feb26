public static class CharacterClassDefinition
{
    public static CharacterClass GetClass(CharacterBuild build) => build switch
    {
        CharacterBuild.Warrior => new CharacterClass(build, 1.1, "Sword"),
        CharacterBuild.Mage => new CharacterClass(build, 1.1, "Staff"),
        CharacterBuild.Ranger => new CharacterClass(build, 1.1, "Bow"),
        CharacterBuild.Healer => new CharacterClass(build, 1.1, "Wand"),
        _ => new CharacterClass(build, 1.1, "Stick")
    };
}