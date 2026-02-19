namespace Basic_Week_One;

class Program
{
    static void Main(string[] args)
    {
        // var calc = new Calculator();

        // calc.RunCalculator();

        var celcius = TemperatureConverter.ConvertToCelsius(20);
        Console.WriteLine(celcius);
        var fahren = TemperatureConverter.ConvertToFahrenheit(celcius);
        Console.WriteLine(fahren);

        var playerOne = new Player(200, 250, [""], new CharacterClass("Warrior", "Helmet", "Chainmail", "Platelegs", 2.2, "Sword", 1));
        playerOne.Attack(playerOne.CharacterClass!);
    }
}