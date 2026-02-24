using Spectre.Console;
public static class UI
{
    /// <summary>
    /// Ask the user for a written input, and store that input as a username
    /// </summary>
    /// <returns>string</returns>
    public static string AskPlayerForName()
    {
        return AnsiConsole.Ask<string>("[green]Choose a username:[/]");
    }

    /// <summary>
    /// Get the character build, the player wants to play
    /// </summary>
    /// <returns>CharacterBuild</returns>
    public static CharacterBuild GetCharacterBuild()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<CharacterBuild>().Title("[green]Choose your character build:[/]").AddChoices(CharacterBuild.Warrior, CharacterBuild.Mage, CharacterBuild.Ranger, CharacterBuild.Healer)
        );
    }
}