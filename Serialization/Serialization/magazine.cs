using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JournalTask4
{
    public class Article
    {
        public string Title { get; set; }
        public int SymbolCount { get; set; }
        public string Preview { get; set; }

        public override string ToString() => $"{Title} ({SymbolCount} символів): {Preview}";
    }

    public class Journal
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int PageCount { get; set; }
        public List<Article> Articles { get; set; } = new List<Article>();

        public override string ToString()
        {
            string result = $"Назва: {Title}\nВидавництво: {Publisher}\nДата: {ReleaseDate.ToShortDateString()}\nСторінок: {PageCount}\nСтатті:";
            foreach (var a in Articles)
                result += $"\n  - {a}";
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Journal> journals = new List<Journal>();

            Console.Write("Скільки журналів додати? ");
            int journalCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < journalCount; i++)
            {
                Console.WriteLine($"\nЖУРНАЛ {i + 1}");
                Journal journal = new Journal();

                Console.Write("Назва журналу: ");
                journal.Title = Console.ReadLine();

                Console.Write("Видавництво: ");
                journal.Publisher = Console.ReadLine();

                Console.Write("Дата випуску: ");
                journal.ReleaseDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Кількість сторінок: ");
                journal.PageCount = int.Parse(Console.ReadLine());

                Console.Write("Скільки статей? ");
                int articleCount = int.Parse(Console.ReadLine());

                for (int j = 0; j < articleCount; j++)
                {
                    Console.WriteLine($"  Стаття {j + 1}:");
                    Article article = new Article();

                    Console.Write("    Назва: ");
                    article.Title = Console.ReadLine();

                    Console.Write("    Кількість символів: ");
                    article.SymbolCount = int.Parse(Console.ReadLine());

                    Console.Write("    Анонс: ");
                    article.Preview = Console.ReadLine();

                    journal.Articles.Add(article);
                }

                journals.Add(journal);
            }

            string json = JsonSerializer.Serialize(journals, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("journals_array.json", json);
            Console.WriteLine("\nМасив журналів збережено у файл journals_array.json");

            // Десеріалізація
            string loadedJson = File.ReadAllText("journals_array.json");
            List<Journal> loadedJournals = JsonSerializer.Deserialize<List<Journal>>(loadedJson);

            Console.WriteLine("\nЗавантажені журнали:");
            foreach (var j in loadedJournals)
            {
                Console.WriteLine("\n" + j);
            }

            Console.ReadKey();
        }
    }
}
