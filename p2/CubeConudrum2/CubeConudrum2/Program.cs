using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        var promptInput = File.ReadAllLines("input.in").ToArray();
        int sum = 0;
        Regex[] colorsRx =
        {
            new(@"\b(\d+)\b\sred"),
            new(@"\b(\d+)\b\sblue"),
            new(@"\b(\d+)\b\sgreen")
        };

        foreach (string prompt in promptInput)
        {
            var minDiceRequired = new List<int>();

            foreach (var color in colorsRx)
            {
                var rxResult = color.Matches(prompt);
                if (rxResult.Count() > 0)
                {
                    int colorMin = 0;
                    for (int i = 0; i < rxResult.Count; i++) 
                    {
                        int colorNumber = int.Parse(rxResult[i].Groups[1].Value);

                        if (colorNumber > colorMin)
                        {
                            colorMin = colorNumber;
                        }
                    }
                    minDiceRequired.Add(colorMin);
                }
            }

            sum += minDiceRequired[0] * minDiceRequired[1] * minDiceRequired[2];
        }
        Console.WriteLine(sum);
    }
}