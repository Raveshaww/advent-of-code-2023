using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        var rows = File.ReadLines("input.in").ToList();
        var sum = 0;

        foreach (var row in rows)
        {
            Regex numbersRx = new(@"\d+");
            var gameSplit = row.Split('|')[0].Split(':')[0] ;
            var winningSplit = numbersRx.Matches(row.Split('|')[0].Split(':')[1]);
            var yourNumbers = numbersRx.Matches(row.Split('|')[1]);
            var winningNumbersList = new List<int>();
            var yourNumbersList = new List<int>();
            var points = 0;
            
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
                    if (points == 0)
                    {
                        points++;
                    }
                    else
                    {
                        points *= 2;
                    }
                }  
            }
            sum += points;
            Console.WriteLine($"{gameSplit}: {points} points." );
        }
        Console.WriteLine($"Grand total: {sum}");
    }
}