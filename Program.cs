using System.Security.Cryptography;

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

        var name = UI.AskPlayerForName();
        Console.WriteLine(name);
        var build = UI.GetCharacterBuild();
        Console.WriteLine($"{name} chose to play the {build} build!");

    }
}