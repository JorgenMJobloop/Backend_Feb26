/// <summary>
/// A class that act as a blueprint for a calculator
/// </summary>
public class Calculator
{
    /// <summary>
    /// Value of number A
    /// </summary>
    private double A;
    /// <summary>
    /// Value of number B
    /// </summary>
    private double B;

    /// <summary>
    /// Add together two whole numbers a + b and return the sum of them
    /// </summary>
    /// <param name="a">value of number a</param>
    /// <param name="b">value of number b</param>
    /// <returns>sum of a + b</returns>
    public int Add(int a, int b)
    {
        return a + b;
    }

    /// <summary>
    /// Add together two decimal numbers a + b and return the sum of them
    /// </summary>
    /// <param name="a">value of number a</param>
    /// <param name="b">value of number b</param>
    /// <returns>sum of a + b</returns>
    public double Add(double a, double b)
    {
        return a + b;
    }

    public double Subtract(double a, double b)
    {
        return a - b;
    }
    /// <summary>
    /// Multiplies two whole numbers a * b and returns the sum of them
    /// </summary>
    /// <param name="a">value of number a</param>
    /// <param name="b">value of number b</param>
    /// <returns>sum of a * b</returns>
    public int Multiply(int a, int b)
    {
        return a * b;
    }
    /// <summary>
    /// Multiplies two decimal numbers a * b and returns the sum of them
    /// </summary>
    /// <param name="a">value of number a</param>
    /// <param name="b">value of number b</param>
    /// <returns>sum of a * b</returns>
    public double Multiply(double a, double b)
    {
        return a * b;
    }
    /// <summary>
    /// Divides a whole number a with divisor b
    /// </summary>
    /// <param name="a">value of a</param>
    /// <param name="b">value of b</param>
    /// <returns>sum of a / b if b does not equal zero</returns>
    /// <exception cref="DivideByZeroException"/>
    public int Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero!");
        }
        return a / b;
    }
    /// <summary>
    /// Divides a number a with divisor b if b does not equal zero
    /// </summary>
    /// <param name="a">value of a</param>
    /// <param name="b">value of b</param>
    /// <returns>sum of a / b</returns>
    /// <exception cref="DivideByZeroException">if divisor is 0</exception>
    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by 0");
        }
        return a / b;
    }

    public double Mod(double a, double mod)
    {
        return a % mod;
    }

    /// <summary>
    /// Run the calculator as a commandline program
    /// </summary>
    public void RunCalculator()
    {
        Console.WriteLine("Select operation:\n['+', '-', '*', '/', '%']");
        // get the operation by user input from keyboard

        double sum;

        while (true)
        {
            Console.Write("> ");
            var operation = Console.ReadLine();
            // evaluate the operation and get the correct sum
            switch (operation!.ToLower())
            {
                case "+":
                    {
                        Console.WriteLine("Enter value of number a:");
                        var a = Console.ReadLine();
                        double.TryParse(a, out A);
                        Console.WriteLine("Enter the value of number b:");
                        var b = Console.ReadLine();
                        double.TryParse(b, out B);
                        sum = Add(A, B);
                        Console.WriteLine($"{a} + {b} = {sum}");
                        break;
                    }
                case "-":
                    {
                        Console.WriteLine("Enter value of number a:");
                        var a = Console.ReadLine();
                        double.TryParse(a, out A);
                        Console.WriteLine("Enter the value of number b:");
                        var b = Console.ReadLine();
                        double.TryParse(b, out B);
                        sum = Subtract(A, B);
                        Console.WriteLine($"{a} - {b} = {sum}");
                        break;
                    }
                case "*":
                    {
                        Console.WriteLine("Enter value of number a:");
                        var a = Console.ReadLine();
                        double.TryParse(a, out A);
                        Console.WriteLine("Enter the value of number b:");
                        var b = Console.ReadLine();
                        double.TryParse(b, out B);
                        sum = Multiply(A, B);
                        Console.WriteLine($"{a} * {b} = {sum}");
                        break;
                    }
                case "/":
                    {
                        Console.WriteLine("Enter value of number a:");
                        var a = Console.ReadLine();
                        double.TryParse(a, out A);
                        Console.WriteLine("Enter the value of number b:");
                        var b = Console.ReadLine();
                        double.TryParse(b, out B);
                        sum = Divide(A, B);
                        Console.WriteLine($"{a} / {b} = {sum}");
                        break;
                    }
                case "%":
                    {
                        Console.WriteLine("Enter value of number a:");
                        var a = Console.ReadLine();
                        double.TryParse(a, out A);
                        Console.WriteLine("Enter the value of number b:");
                        var b = Console.ReadLine();
                        double.TryParse(b, out B);
                        sum = Mod(A, B);
                        Console.WriteLine($"{a} % {b} = {sum}");
                        break;
                    }
                case "exit":
                    break;
                default:
                    return;
            }
            if (operation == "exit")
            {
                return;
            }
        }
    }

}