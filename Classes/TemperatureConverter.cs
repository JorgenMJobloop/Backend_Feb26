public static class TemperatureConverter
{
    public static double ConvertToCelsius(double F)
    {
        return (F - 32) * 5 / 9;
    }

    public static double ConvertToFahrenheit(double C)
    {
        return C * (9 / 5) + 32;
    }
}