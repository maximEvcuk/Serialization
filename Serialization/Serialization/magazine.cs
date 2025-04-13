using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JournalTask3
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
            Journal journal = new Journal();

            Console.Write("Назва журналу: ");
            journal.Title = Console.ReadLine();

            Console.Write("Видавництво: ");
            journal.Publisher = Console.ReadLine();

            Console.Write("Дата випуску: ");
            journal.ReleaseDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Кількість сторінок: ");
            journal.PageCount = int.Parse(Console.ReadLine());

            Console.Write("Скільки статей додати? ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Стаття {i + 1}:");
                Article article = new Article();

                Console.Write("  Назва: ");
                article.Title = Console.ReadLine();

                Console.Write("  Кількість символів: ");
                article.SymbolCount = int.Parse(Console.ReadLine());

                Console.Write("  Анонс: ");
                article.Preview = Console.ReadLine();

                journal.Articles.Add(article);
            }

            string json = JsonSerializer.Serialize(journal, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("journal_with_articles.json", json);
            Console.WriteLine("\nЗбережено в journal_with_articles.json");

            // Десеріалізація
            string loadedJson = File.ReadAllText("journal_with_articles.json");
            Journal loaded = JsonSerializer.Deserialize<Journal>(loadedJson);

            Console.WriteLine("\nЗавантажений журнал:");
            Console.WriteLine(loaded);

            Console.ReadKey();
        }
    }
}
