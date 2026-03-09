using Spectre.Console;

public static class PartyAI
{
    public static void TakeTurn(Random rng, Party partyMember, Player player, List<NPC> enemies)
    {
        if (!partyMember.IsAlive)
        {
            return;
        }

        var aliveEnemies = enemies.Where(enemy => enemy.IsAlive).ToList();

        if (aliveEnemies.Count == 0)
        {
            return;
        }

        switch (partyMember.Role)
        {
            case PartyMember.Healer:

                var allies = new List<IBattleEngine>()
                {
                    player
                };

                allies.AddRange(player.PartyMembers);

                var needsHealing = allies.Where(ally => ally.IsAlive).OrderBy(ally => ally.HP / ally.MaxHP).First();

                // a healing spell, costs 10 mana.
                if (partyMember.Mana >= 10 && (needsHealing.HP / needsHealing.MaxHP) < 0.5)
                {
                    partyMember.SpendMana(10);
                    needsHealing.Heal(22); // heal 22 hp.
                    AnsiConsole.MarkupLine($"[green]{partyMember.Name} heals {needsHealing.Name} (+22) - HP: {needsHealing.HP}[/]");
                }
                else
                {
                    Attack(rng, partyMember, aliveEnemies[rng.Next(aliveEnemies.Count)]);
                }
                break;
        }
    }

    private static void Attack(Random rng, IBattleEngine attacker, IBattleEngine enemy)
    {
        // tuple variable, containing |hit,crit & dmg| 
        var (hit, crit, dmg) = CombatHelper.ResolveAttacks(rng, attacker.Accuracy, attacker.CritChance, attacker.BaseDamage);

        if (!hit)
        {
            AnsiConsole.MarkupLine($"[red bold]{attacker.Name} missed {enemy.Name}![/]");
            return;
        }

        enemy.TakeDamage(dmg);
        // handle critical hits
        var critText = crit ? "[#D75F00](CRIT)[/]" : string.Empty;
        AnsiConsole.MarkupLine($"[white]{attacker.Name} hit {enemy.Name} for [red]{dmg}[/].{critText}");
    }
}