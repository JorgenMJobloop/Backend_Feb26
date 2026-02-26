using System.Security.Cryptography;
using Spectre.Console;

namespace Basic_Week_One;

class Program
{
    static void Main(string[] args)
    {
        // var calc = new Calculator();

        // calc.RunCalculator();

        // var celcius = TemperatureConverter.ConvertToCelsius(20);
        // Console.WriteLine(celcius);
        // var fahren = TemperatureConverter.ConvertToFahrenheit(celcius);
        // Console.WriteLine(fahren);

        // var warrior = new CharacterClass(CharacterBuild.Warrior, 0.5, "Sword");
        // var player = new Player(name: "Rambo", characterClass: warrior);


        // var npc = new NPC
        // {
        //     TypeOfFoe = "Goblin",
        //     XPWhenDefeated = 30,
        //     HP = 100,
        //     BaseDamage = 7
        // };

        // npc.DropTable.Add(new LootEntry("Coins", weigth: 60, minimumAmount: 3, maximumAmount: 30));
        // npc.DropTable.Add(new LootEntry("Health Restoration Potion", weigth: 25, minimumAmount: 1, maximumAmount: 2));
        // npc.DropTable.Add(new LootEntry("Rusty Dagger", weigth: 10));

        // var battle = new BattleEngine();
        // battle.Fight(player, npc);

        var state = new GameState();

        // Create a new player
        AnsiConsole.Clear();
        var name = UI.AskPlayerForName();
        var build = UI.GetCharacterBuild();

        // get the different starter classes
        var starterClasses = build switch
        {
            CharacterBuild.Warrior => new CharacterClass(build, 1.1, "Sword"),
            CharacterBuild.Mage => new CharacterClass(build, 1.1, "Staff"),
            CharacterBuild.Ranger => new CharacterClass(build, 1.1, "Bow"),
            CharacterBuild.Healer => new CharacterClass(build, 1.1, "Wand"),
            _ => new CharacterClass(build, 1.1, "Stick")
        };

        var goblin = NPCHelper.CreateNPCFromTempate(NPCHelper.CreateGoblinNPC());

        state.Player = new Player(name, starterClasses);

        // Main game loop
        while (state.Screen != GameScreen.Exit)
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine($"[bold]{state.Player.Name}[/] | {state.Player.CharacterClass} | HP : {state.Player.HP}");

            var choices = UI.MainActionPrompt(state.Player);

            switch (choices)
            {
                case "Walk":
                    NPCHelper.HandleEncounters(state);
                    break;
                case "Attack":
                    state.CurrentEnemy = goblin;
                    BattleEngine.RunBattle(state);
                    break;
                case "View inventory":
                    UI.ViewInventory(state.Player);
                    break;
                case "Party":
                    UI.ViewPartyMembers(state.Player);
                    break;
                case "Recruit":
                    NPCHelper.HandlePartyMemberRecruitment(state);
                    break;
                case "Exit":
                    state.Screen = GameScreen.Exit;
                    break;
            }
        }
        AnsiConsole.MarkupLine("Exiting game...");
    }
}