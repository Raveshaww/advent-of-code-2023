using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        var rows = File.ReadLines("input.in").ToList();
        Regex numbersRx = new(@"\d+");
        var cardsToRun = new List<int>();

        // Making sure that we have one of each card
        for (int i = 0; i < rows.Count; i++)
        {
            cardsToRun.Add(1);
        }    

        for (int i = 0; i < rows.Count; i++)
        {
            var winningSplit = numbersRx.Matches(rows[i].Split('|')[0].Split(':')[1]);
            var yourNumbers = numbersRx.Matches(rows[i].Split('|')[1]);
            var winningNumbersList = new List<int>();
            var yourNumbersList = new List<int>();
            var matches = 0;

            foreach (Match match in winningSplit)
            {
                winningNumbersList.Add(int.Parse(match.Value));
            }

            foreach (Match match in yourNumbers)
            {
                yourNumbersList.Add(int.Parse(match.Value));
            }

            foreach (var number in yourNumbersList)
            {
                if (winningNumbersList.Contains(number))
                {
                    matches += 1;
                }
            }

            for (int j = 1; j <= matches; j++)
            {
                cardsToRun[i + j] += cardsToRun[i];
            }
        }
        Console.WriteLine(cardsToRun.Sum());
    }
}