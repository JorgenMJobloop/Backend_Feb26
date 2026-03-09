using Spectre.Console;
/// <summary>
/// First iteration
/// Version 0.0.1
/// </summary>
public static class BattleEngine
{
    public static void RunBattle(GameState state)
    {
        var player = state.Player;
        var enemy = state.CurrentEnemy;

        AnsiConsole.Clear();
        AnsiConsole.Write(new Rule($"[red]Battle vs {enemy!.Name}[/]"));

        while (player.HP > 0 && enemy.IsAlive)
        {
            var action = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title($"[bold]{player.Name}[/] HP: [green]{player.HP}[/] | [bold]{enemy.Name}[/] Enemy HP: {enemy.HP}").AddChoices("Attack", "Run")
            );

            if (action == "Run")
            {
                AnsiConsole.MarkupLine("[gray]You managed to run away from the enemy...[/]");
                Console.ReadKey(true);
                return;
            }

            // if the player does not choose "Run" we implement the battle system
            double damage = Math.Round(20 + state.RNG.NextDouble() * 10, 1);
            enemy.TakeDamage(damage);
            AnsiConsole.MarkupLine($"{enemy.Name} was hit for [green]{damage}[/]");

            if (!enemy.IsAlive)
            {
                break;
            }

            // enemy attacks
            double incomingDamage = Math.Round(enemy.BaseDamage, 1);
            double hp = Math.Max(0, player.HP - incomingDamage);
            AnsiConsole.MarkupLine($"{enemy.Name} hit {player.Name} for [red]{incomingDamage}[/] damage!");
        }

        if (player.HP <= 0)
        {
            AnsiConsole.MarkupLine("[red]You died..[/]");
            Console.ReadKey(true);
            return;
        }

        AnsiConsole.MarkupLine($"[green]{player.Name} defeated {enemy.Name}![/]");

        var loot = enemy.RollLoot(state.RNG, rolls: 2);
        if (loot.Count == 0)
        {
            AnsiConsole.MarkupLine("[grey]No loot found...[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[bold]Loot:[/]");
            foreach (var (item, amount) in loot)
            {
                player.Inventory.Add(item, amount);
                AnsiConsole.MarkupLine($"- {item} : {amount}");
            }
        }

        Console.ReadKey(true);
    }
}