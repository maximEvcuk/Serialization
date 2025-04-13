//using System;
//using System.IO;
//using System.Text.Json;

//namespace JournalTask2
//{
//    public class Journal
//    {
//        public string Title { get; set; }
//        public string Publisher { get; set; }
//        public DateTime ReleaseDate { get; set; }
//        public int PageCount { get; set; }

//        public override string ToString()
//        {
//            return $"Назва: {Title}\nВидавництво: {Publisher}\nДата: {ReleaseDate.ToShortDateString()}\nСторінок: {PageCount}";
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Journal journal = new Journal();

//            Console.Write("Назва журналу: ");
//            journal.Title = Console.ReadLine();

//            Console.Write("Назва видавництва: ");
//            journal.Publisher = Console.ReadLine();

//            Console.Write("Дата випуску (рррр-мм-дд): ");
//            journal.ReleaseDate = DateTime.Parse(Console.ReadLine());

//            Console.Write("Кількість сторінок: ");
//            journal.PageCount = int.Parse(Console.ReadLine());

//            // Серіалізація
//            string json = JsonSerializer.Serialize(journal, new JsonSerializerOptions { WriteIndented = true });
//            File.WriteAllText("journal.json", json);
//            Console.WriteLine("\nЖурнал збережено у файл journal.json");

//            // Десеріалізація
//            string loadedJson = File.ReadAllText("journal.json");
//            Journal loadedJournal = JsonSerializer.Deserialize<Journal>(loadedJson);

//            Console.WriteLine("\nЗавантажений журнал:");
//            Console.WriteLine(loadedJournal);

//            Console.WriteLine("\nНатисніть будь-яку клавішу...");
//            Console.ReadKey();
//        }
//    }
//}
