using System.Diagnostics;
using System.Text.Json;

namespace OtusReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Замер времени на сериализацию
            var serializer = new CsvSerializer();

            var f = F.Get();

            int iterations = 100000;

            var stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < iterations; i++)
            {
                var csv = serializer.Serialize(f);
            }

            stopwatch.Stop();

            Console.WriteLine($"Время сериализации: {stopwatch.ElapsedMilliseconds} мс для {iterations} итераций");

            //Замер времени на вывод текста в консоль
            var consoleStopwatch = Stopwatch.StartNew();

            Console.WriteLine("Пример вывода");

            consoleStopwatch.Stop();

            Console.WriteLine($"Время вывода в консоль: {consoleStopwatch.ElapsedMilliseconds} мс");


            //Сериализация с использованием стандартных механизмов (JSON)
            var jsonStopwatch = Stopwatch.StartNew();

            for (int i = 0; i < iterations; i++)
            {
                var json = JsonSerializer.Serialize(f);
            }

            jsonStopwatch.Stop();

            Console.WriteLine($"Время JSON сериализации: {jsonStopwatch.ElapsedMilliseconds} мс для {iterations} итераций");

            //Десериализация


            // Замер времени на десериализацию

            var deserializeStopwatch = Stopwatch.StartNew();

            for (int i = 0; i < iterations; i++)
            {
                var deserializedF = F.Deserialize(serializer.Serialize(f));
            }
            deserializeStopwatch.Stop();
            Console.WriteLine($"Время десериализации: {deserializeStopwatch.ElapsedMilliseconds} мс для {iterations} итераций");
        }
    }
}
