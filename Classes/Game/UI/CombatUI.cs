using Spectre.Console;
public enum PlayerActions
{
    Attack = 1,
    UsePotions = 2,
    Defend = 3,
    Run = 4
}
public static class CombatUI
{
    /// <summary>
    /// Get the players action in the context of a UI (user-interface)
    /// </summary>
    /// <param name="player">Player</param>
    /// <returns>Player Action</returns>
    public static PlayerActions GetPlayerAction(Player player)
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<PlayerActions>()
            .Title($"[bold green]{player.Name}[/] - choose action")
            .AddChoices(PlayerActions.Attack, PlayerActions.UsePotions, PlayerActions.Defend, PlayerActions.Run)
        );
    }

    /// <summary>
    /// Get all available targets for combat encounters
    /// </summary>
    /// <param name="title">name of target</param>
    /// <param name="targets">all enemies</param>
    /// <returns>IBattleSystem</returns>
    public static IBattleSystem GetTarget(string title, IEnumerable<IBattleSystem> targets)
    {
        var alive = targets.Where(target => target.IsAlive).ToList();

        return AnsiConsole.Prompt(
            new SelectionPrompt<IBattleSystem>()
            .Title(title)
            .UseConverter(target => target.Name)
            .AddChoices(alive)
        );
    }
}