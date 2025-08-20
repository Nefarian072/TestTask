using TestTask;

public class Program
{
    public static void Main()
    {
        var inputPath = "input.txt";
        var outputPath = "output.txt";
        var lines = File.ReadAllLines(inputPath);
        var draw = new Draw(lines);

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