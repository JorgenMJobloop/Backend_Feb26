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

        var warrior = new CharacterClass(build: "Warrior", head: "Helmet", body: "Armor", feet: "Platelegs", multiplier: 1.2, weapon: "Sword", baseLevel: 1);
        var player = new Player(name: "Rambo", hp: 100, mana: 0, character: warrior);

        var npc = new NPC
        {
            TypeOfFoe = "Goblin",
            XPWhenDefeated = 30,
            HP = 100,
            BaseDamage = 7
        };

        var battle = new BattleEngine();
        battle.Fight(player, npc);

    }
}