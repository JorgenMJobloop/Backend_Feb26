namespace Basic_Week_One;

class Program
{
    static void Main(string[] args)
    {
        // john is in this case a object instance of our Person class.
        var john = new Person
        {
            Name = "John",
            Birthday = "1/1/1992",
            Age = 34,
            Hobbies = ["Programming", "Gaming"]
        };

        var jane = new Person
        {
            Name = "Jane",
            Birthday = "5/10/1993",
            Age = 33,
            Hobbies = ["Skiing", "Soccer", "Programming"]
        };

        john.PrintInformation();

        jane.PrintInformation();


        // Challenges

        // Challenge one: print a name out in the console
        // hint: Console.ReadLine();

        // Challenge two: add a number (x) with a number (y) together
        // hint: int x, int y(double x, double y)

        // Challenge three: create a new List of strings & print the contents of the list
        // hint: List<string> myItems = ["", ""];
    }
}