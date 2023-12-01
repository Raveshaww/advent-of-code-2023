internal class Program
{
    private static void Main(string[] args)
    {
        var promptInput = File.ReadAllLines("input.in").ToArray();
        var numberWords = new (string text, int value)[] {
            ("one", 1),
            ("two", 2),
            ("three", 3),
            ("four", 4),
            ("five", 5),
            ("six", 6),
            ("seven", 7),
            ("eight", 8),
            ("nine", 9),
        };
        var cleanedPromptInput = new List<string>();
        int total = 0;

        foreach ( string prompt in promptInput ) 
        {
            int first = 0;
            int last = 0;
            bool found = false;

            for (var i = 0; !found && i < prompt.Length; i++) 
            { 
                if (char.IsDigit(prompt[i]))
                {
                    first = int.Parse(prompt[i].ToString());
                    //first = prompt[i];
                    found = true;
                }

                // Now to start searching for words
                for (var j = 0; !found && j < numberWords.Length; j++) 
                {
                    // the .. basically means "to the end of the string"
                    if (prompt[i..].StartsWith(numberWords[j].text))
                    { 
                        first = numberWords[j].value;
                        found = true;
                    }
                }
            }

            // Basically just to be safe and reset the flag
            found = false; 
            for (var i = prompt.Length - 1; !found && i >= 0; i--)
            {
                if (char.IsDigit(prompt[i]))
                {
                    last = int.Parse(prompt[i].ToString());
                    found = true;
                }

                // Now to start searching for words
                for (var j = 0; !found && j < numberWords.Length; j++)
                {
                    if (prompt[..(i + 1)].EndsWith(numberWords[j].text))
                    {
                        last = numberWords[j].value;
                        found = true;
                    }
                }
            }
            cleanedPromptInput.Add($"{first}{last}");
        }

        IEnumerable<string> stringResults =
            from input in cleanedPromptInput
            select string.Concat(input.Where(char.IsDigit).First(), input.Where(char.IsDigit).Last());


        foreach (var i in stringResults)
        {
            Console.WriteLine(i);
            total += int.Parse(i);
        }

        Console.WriteLine($"\nThe total is: {total}");
    }
}