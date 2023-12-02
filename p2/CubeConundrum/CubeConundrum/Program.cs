using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        var promptInput = File.ReadAllLines("input.in").ToArray();
        int sum = 0;
        Regex[] colorsRx =
        {
            new(@"\b(1[3-9]|[2-9]\d+)\b red"),
            new(@"\b(1[4-9]|[2-9]\d+)\b green"),
            new(@"\b(1[5-9]|[2-9]\d+)\b blue")
        };

        foreach (string prompt in promptInput)
        {
            bool validGame = true;

            foreach (var color in colorsRx)
            {
                if (color.Matches(prompt).Count() >= 1)
                {
                    validGame = false;
                    break;
                }
            }

            if (validGame)
            {
                sum += int.Parse(prompt.Split(":")[0].Split(" ")[1]);
            }
        }
        Console.WriteLine(sum);
    }
}