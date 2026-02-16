public class Person
{
    public string? Name;
    public int Age;
    public List<string> Hobbies = new List<string>();
    public string? Birthday;


    public string GetPersonsName()
    {
        return Name!;
    }

    public int GetPersonsAge()
    {
        return Age;
    }

    public void PrintInformation()
    {
        Console.WriteLine($"Name: {Name} Age: {Age}, Birthday: {Birthday} Hobbies: {string.Join(", ", Hobbies)}");
    }
}