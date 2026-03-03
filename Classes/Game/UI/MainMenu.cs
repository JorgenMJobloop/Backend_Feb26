using Spectre.Console;
public static class MainMenu
{
    public static GameState StartMenu()
    {
        var saveFile = SaveGameService.DefaultSaveFileName();

        while (true)
        {
            AnsiConsole.Clear();

            var choices = new List<string>()
            {
                "New Game"
            };

            if (File.Exists(saveFile))
            {
                choices.Add("Continue");
                choices.Add("Load Game");
            }

            choices.Add("Exit");

            var userInput = AnsiConsole.Prompt(
                new SelectionPrompt<string>().Title("[bold green]Main Menu[/]").AddChoices(choices)
            );

            switch (userInput)
            {
                case "New Game":
                    return NewGame();

                case "Continue":
                case "Load Game":
                    if (SaveGameService.TryLoadFile(saveFile, out var save, out var errorMessage))
                    {
                        return SaveGameMapper.MapLoad(save!);
                    }
                    AnsiConsole.MarkupLine($"[red]{errorMessage}[/]");
                    Console.ReadKey(true);
                    break;
                case "Exit":
                    Environment.Exit(0);
                    return null!;
            }
        }
    }

    public static GameState NewGame()
    {
        var name = UI.AskPlayerForName();
        var build = UI.GetCharacterBuild();

        var player = new Player(name, 1, 1, 1, 30, CharacterClassDefinition.GetClass(build));

        // starter items
        player.Inventory.Add("Health Potion", 2);
        player.Inventory.Add("Gold Coins", 50);

        return new GameState { Player = player };
    }
}