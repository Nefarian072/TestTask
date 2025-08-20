using TestTask;

public class Program
{
    public static void Main()
    {
        var inputPath = "input.txt";
        var outputPath = "output.txt";

        var athletes = File.ReadAllLines(inputPath)
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(line =>
            {
                var parts = line.Split(',', 2);
                return new Athlete(parts[0].Trim(), parts[1].Trim());
            })
            .ToList();

        var draw = new Draw(athletes);
        var result = draw.Arrange();
        if (result == null)
        {
            Console.WriteLine("Невозможно расставить спортсменов по условию!");
            return;
        }

        File.WriteAllLines(outputPath, result.Select(a => a.FullInfo));
        Console.WriteLine("Жеребьевка завершена. Результат записан в " + outputPath);
    }
}