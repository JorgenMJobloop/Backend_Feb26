using Spectre.Console;

public static class NPCHelper
{
    private static Random _rng = new Random();
    private static List<string> Gems = ["Emerald", "Sapphire", "Opal", "Ruby", "Diamond"];

    /// <summary>
    /// Create a new NPC using this method as a template
    /// </summary>
    /// <param name="template">the NPC to create</param>
    /// <returns>NPC</returns>
    public static NPC CreateNPCFromTempate(NPC template)
    {
        var enemy = new NPC { Name = template.Name, HP = template.HP, BaseDamage = template.BaseDamage };

        foreach (var item in template.DropTable)
        {
            enemy.DropTable.Add(item);
        }

        return enemy;
    }

    /// <summary>
    /// NPC template for a Goblin NPC
    /// </summary>
    /// <returns>NPC</returns>
    public static NPC CreateGoblinNPC()
    {
        var goblin = new NPC { Name = "Goblin", HP = 30, BaseDamage = 7 };
        goblin.DropTable.Add(new LootEntry("Gold Coin", Rarity.Common, weight: 60, minimumAmount: 3, maximumAmount: 100));
        goblin.DropTable.Add(new LootEntry("Health Potion", Rarity.Common, weight: 25, minimumAmount: 1, maximumAmount: 2));
        goblin.DropTable.Add(new LootEntry("Rusty Dagger", Rarity.Uncommon, weight: 12));
        goblin.DropTable.Add(new LootEntry(GetRandomGem(Gems), Rarity.Rare, weight: 3));
        goblin.DropTable.Add(new LootEntry("Mithril Sword", Rarity.Mythic, weight: 3));
        goblin.DropTable.Add(new LootEntry("Soiled Loin Cloth", Rarity.Legendary, weight: 2));

        return goblin;
    }
    /// <summary>
    /// Handle random encounters
    /// </summary>
    /// <param name="state">gamestate</param>
    public static void HandleEncounters(GameState state)
    {
        if (state.RNG.NextDouble() < 0.40)
        {
            state.CurrentEnemy = CreateNPCFromTempate(CreateGoblinNPC());
            BattleEngine.RunBattle(state);
            return;
        }

        AnsiConsole.MarkupLine("[grey]You walk around, but spot no enemies..[/]");
        Console.ReadKey(true);
    }

    /// <summary>
    /// Handle party member recruitment
    /// </summary>
    /// <param name="state">gamestate</param>
    public static void HandlePartyMemberRecruitment(GameState state)
    {
        var player = state.Player;

        var npcBuild = AnsiConsole.Prompt(
            new SelectionPrompt<CharacterBuild>().Title("[yellow]Recruit a new party member?[/]")
            .AddChoices(CharacterBuild.Warrior, CharacterBuild.Mage, CharacterBuild.Ranger, CharacterBuild.Healer)
        );

        var partyMember = npcBuild switch
        {
            CharacterBuild.Warrior => new CharacterClass(npcBuild, 1.05, "Axe"),
            CharacterBuild.Mage => new CharacterClass(npcBuild, 1.05, "Tome"),
            CharacterBuild.Ranger => new CharacterClass(npcBuild, 1.05, "Shortbow"),
            CharacterBuild.Healer => new CharacterClass(npcBuild, 1.05, "Holy Staff"),
            _ => new CharacterClass(npcBuild, 1.0, "Stick")
        };

        player.Party!.Recruit(partyMember);
        AnsiConsole.MarkupLine($"[green]Recruited:[/] {partyMember.Build} ({partyMember.Weapon})");
        Console.ReadKey(true);
    }

    /// <summary>
    /// Helper method to return a random gem from a list of different gems
    /// </summary>
    /// <param name="gems"></param>
    /// <returns>string</returns>
    private static string GetRandomGem(List<string> gems)
    {
        return gems[_rng.Next(gems.Count)].ToString();
    }
}