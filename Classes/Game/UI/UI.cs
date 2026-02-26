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

    /// <summary>
    /// A prompt containing the main actions that a player can perform
    /// </summary>
    /// <param name="player">main player</param>
    /// <returns>string</returns>
    public static string MainActionPrompt(Player player)
    {
        var prompt = new SelectionPrompt<string>()
            .Title($"[bold]What would you like to do {player.Name}?[/]")
            .AddChoices("Walk", "Attack", "View inventory", "Party", "Recruit", "Exit");

        return AnsiConsole.Prompt(prompt);
    }

    /// <summary>
    /// Display the contents inside of the players inventory
    /// </summary>
    /// <param name="player">main player</param>
    public static void ViewInventory(Player player)
    {
        // Clear the console when this method is being ran
        AnsiConsole.Clear();
        AnsiConsole.Write(new Rule("[bold]Inventory[/]"));

        // Check if the inventory is empty
        if (player.Inventory.IsEmpty)
        {
            AnsiConsole.MarkupLine("[grey](empty)[/]");
            AnsiConsole.MarkupLine("Press any key to return...");
            Console.ReadKey(true);
            return;
        }

        var table = new Table().AddColumn("Item").AddColumn("Amount");

        // loop through the Inventory dictionary to get the keys and the values associated with them
        foreach (var keyValuePair in player.Inventory.Items.OrderBy(key => key.Key))
        {
            table.AddRow(keyValuePair.Key, keyValuePair.Value.ToString());
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("Press any key to return...");
        Console.ReadKey(true);
    }

    /// <summary>
    /// View the current members in your party
    /// </summary>
    /// <param name="player">main player</param>
    public static void ViewPartyMembers(Player player)
    {
        AnsiConsole.Clear();
        AnsiConsole.Write(new Rule("[bold]Party[/]"));

        if (player.Party!.Companions.Count == 0)
        {
            AnsiConsole.MarkupLine("[grey]No party members are currently recruited.[/]");
        }
        else
        {
            var table = new Table().AddColumn("Party Members");

            foreach (var member in player.Party.Companions)
            {
                table.AddRow($"{member.Build} ({member.Weapon})");
            }
            AnsiConsole.Write(table);
        }

        AnsiConsole.MarkupLine("Press any key to return...");
        Console.ReadKey(true);
    }

}