using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        var rows = File.ReadLines("testInput.in").ToList();
        var sum = 0;
        Regex numberRx = new(@"\d+");
        var gears = new List<(int row, int column)>();

        // loop through the rows
        for (int i = 0; i < rows.Count; i++)
        {
            // get the current row
            var row = rows[i];

            // Loop through each match in the row
            foreach (Match match in numberRx.Matches(row))
            {
                var value = int.Parse(match.Value);

                var startingIndex = match.Index;
                var endingIndex = startingIndex + match.Length - 1;

                var neighborsCells = GetNeighborCells(startingIndex, endingIndex, i, rows.Count, row.Length);
                var isNextToGear = GearCheck(neighborsCells, rows);

                if (isNextToGear)
                {
                    sum += value;
                }
            }
        }
        Console.WriteLine($"Sum is: {sum}");
    }

    // Makes a list of tuples
    // rowIndex is the row referenced in the original for loop
    public static List<(int row, int column)> GetNeighborCells(int startingIndex, int endingIndex, int rowIndex, int numRows, int numColumns)
    {
        var neighborCells = new List<(int row, int column)>();

        // Loop through rows above and below. Remember, up to but not including
        for (int i = rowIndex - 1; i < rowIndex + 2; i++)
        {
            for (int j = startingIndex - 1; j < endingIndex + 2; j++)
            {
                neighborCells.Add((i, j));
            }
        }

        // Filter out cells that are outside the bounds of the grid
        return neighborCells
            .Where(cells => cells.row >= 0 && cells.row < numRows && cells.column >= 0 && cells.column < numColumns)
            .ToList();
    }

    public static bool GearCheck(List<(int row, int column)> cells, List<string> rows)
    {
        foreach (var cell in cells)
        {
            var character = rows[cell.row][cell.column];

            if (character == '*')
            {
                Console.WriteLine($"row: {cell.row}, column: {cell.column}");
                return true;
            }
        }
        return false;
    }
}