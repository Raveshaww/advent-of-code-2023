using System.Numerics;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        var promptInput = File.ReadAllLines("input.in").ToArray();

        int total = 0;

        IEnumerable<string> stringResults =
            from input in promptInput
            select string.Concat(input.Where(char.IsDigit).First(), input.Where(char.IsDigit).Last());

        
        foreach (var i in stringResults)
        {
            Console.WriteLine(i);
            total += int.Parse(i);
        }

        Console.WriteLine($"\nThe total is: {total}");
    }
}