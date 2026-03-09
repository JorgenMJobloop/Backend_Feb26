using Spectre.Console;

public sealed class BattleResults
{
    public bool PlayerWon { get; init; }
    public bool PlayerEscaped { get; init; }
}
public static class BattleSystemHandler
{
    /// <summary>
    /// Get the results of a given battle
    /// </summary>
    /// <param name="player">player</param>
    /// <param name="enemies">current enemy that is being battled</param>
    /// <param name="rng">Random Number Generator</param>
    /// <returns>BattleResults</returns>
    public static BattleResults GetBattleResult(Player player, List<NPC> enemies, Random rng)
    {
        // Clear the console before outputting back the results of a battle
        AnsiConsole.Clear();
        AnsiConsole.Write(new Rule("[red]Battle[/]"));

        while (player.IsAlive && enemies.Any(e => e.IsAlive))
        {
            // we reset at the start of each round (this applies to all entities as well as the player)
            player.IsCurrentlyDefending = false;

            foreach (var partyMember in player.PartyMembers)
            {
                partyMember.IsCurrentlyDefending = false;
            }

            foreach (var enemy in enemies)
            {
                enemy.IsCurrentlyDefending = false;
            }

            DrawStatus(player, enemies);

            var allEntities = new List<IBattleSystem> { player };
            allEntities.AddRange(player.PartyMembers);
            allEntities.AddRange(enemies);

            var turnOrder = TurnOrderHelper.BuildCombatOrder(rng, allEntities);

            foreach (var actor in turnOrder)
            {
                if (!player.IsAlive)
                {
                    break;
                }

                if (!enemies.Any(enemy => enemy.IsAlive))
                {
                    break;
                }

                if (!actor.IsAlive)
                {
                    continue;
                }

                if (ReferenceEquals(actor, player))
                {
                    var battleResult = PlayerCombatTurn(player, enemies, rng);

                    if (battleResult == PlayerActions.Run)
                    {
                        return new BattleResults { PlayerWon = false, PlayerEscaped = true };
                    }
                }
                else if (actor is Party member)
                {
                    PartyAI.TakeTurn(rng, member, player, enemies);
                }
                else if (actor is NPC npc)
                {
                    EnemyTurn(rng, npc, player);
                }
            }
        }

        return new BattleResults { PlayerWon = player.IsAlive, PlayerEscaped = false };
    }

    private static void DrawStatus(Player player, List<NPC> enemies)
    {
        // rendering player data
        var table = new Table().AddColumn("Side").AddColumn("Name").AddColumn("HP").AddColumn("Mana").AddColumn("State");
        table.AddRow("Player", player.Name, $"{player.HP}/{player.MaxHP}", $"{player.Mana}/{player.MaxMana}", player.IsCurrentlyDefending ? "Defending" : "");
        // rendering party members
        foreach (var member in player.PartyMembers)
        {
            table.AddRow("Party", member.Name, $"{member.HP}/{member.MaxHP}", $"{member.Mana}/{member.MaxMana}", member.IsCurrentlyDefending ? "Defending" : "");
        }
        // rendering enemies
        foreach (var enemy in enemies)
        {
            table.AddRow("Enemy", enemy.Name, $"{enemy.HP}/{enemy.MaxHP}", "-", enemy.IsCurrentlyDefending ? "Defending" : "");
        }
        // render the table
        AnsiConsole.Write(table);
        // write out a newline
        AnsiConsole.WriteLine();
    }

    private static PlayerActions PlayerCombatTurn(Player player, List<NPC> enemies, Random rng)
    {
        var action = CombatUI.GetPlayerAction(player);

        switch (action)
        {
            case PlayerActions.Attack:
                var target = (NPC)CombatUI.GetTarget("[bold]Choose a target[/]", enemies);
                PerformAttack(rng, player, target);
                break;
            case PlayerActions.UsePotions:
                break;
            case PlayerActions.Defend:
                player.IsCurrentlyDefending = true;
                AnsiConsole.MarkupLine($"[blue]Took less damage when defending.[/]");
                break;
            case PlayerActions.Run:
                bool escaped = rng.NextDouble() < 0.60;
                if (escaped == true)
                {
                    AnsiConsole.MarkupLine("[green]You managed to escape from the battle![/]");
                    return PlayerActions.Run;
                }
                AnsiConsole.MarkupLine("[red]You did not manage to evade the enemy![/]");
                break;
        }

        return action;
    }

    private static void UsePotion(Player player)
    {
        if (!player.Inventory.Remove(ItemService.HealthPotion.ToString()!, 1))
        {
            AnsiConsole.MarkupLine($"[grey]No health potions in inventory![/]");
            return;
        }
        // if we have a health potion in our inventory, we heal 30 HP and lose one turn.
        player.Heal(30);
        AnsiConsole.MarkupLine("[green]Used Health Potion[/] [red](+30 HP)[/]");
    }

    private static void EnemyTurn(Random rng, NPC npc, Player player)
    {
        // the enemy should do the following: attack a random friendly target (player or friendly NPC/Party member)
        var targets = new List<IBattleSystem> { player };
        targets.AddRange(player.PartyMembers.Where(member => member.IsAlive));

        if (targets.Contains((IBattleSystem)player.PartyMembers.Select(t => t.Role == PartyMember.Tank)))
        {
            // handle tank as default target
        }

        var target = targets[rng.Next(targets.Count)];
        PerformAttack(rng, npc, player);
    }

    private static void PerformAttack(Random rng, IBattleSystem npc, IBattleSystem actor)
    {
        var (hit, crit, dmg) = CombatHelper.ResolveAttacks(rng, npc.Accuracy, npc.CritChance, npc.BaseDamage);

        if (hit == false)
        {
            AnsiConsole.MarkupLine($"[grey]{npc.Name} missed {actor.Name}![/]");
            return;
        }

        actor.TakeDamage(dmg);
        var critText = crit ? "[orange1](CRIT)[/]" : "";
        AnsiConsole.MarkupLine($"{npc.Name} hits {actor.Name} for [red]{dmg}[/]damage!");
    }
}