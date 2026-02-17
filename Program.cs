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
    }
}