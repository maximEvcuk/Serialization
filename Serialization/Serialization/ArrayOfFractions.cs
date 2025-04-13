//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text.Json;

//namespace FractionSerializationApp
//{
   
//    [Serializable]
//    public class Fraction
//    {
//        public int Numerator { get; set; }
//        public int Denominator { get; set; }

//        public override string ToString()
//        {
//            return $"{Numerator}/{Denominator}";
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // 1 Введення масиву  з клавіатури
//            List<Fraction> fractions = new List<Fraction>();

//            Console.Write("Скільки дробів ви хочете ввести? ");
//            int count = int.Parse(Console.ReadLine());

//            for (int i = 0; i < count; i++)
//            {
//                Console.WriteLine($"\nДріб {i + 1}:");

//                Console.Write("  Введіть чисельник: ");
//                int numerator = int.Parse(Console.ReadLine());

//                Console.Write("  Введіть знаменник: ");
//                int denominator = int.Parse(Console.ReadLine());

//                fractions.Add(new Fraction
//                {
//                    Numerator = numerator,
//                    Denominator = denominator
//                });
//            }

//            // 2 Серіалізація масиву дробів у формат JSON
//            string json = JsonSerializer.Serialize(fractions, new JsonSerializerOptions { WriteIndented = true });

//            // 3 Збереження серіалізованого масиву у файл
//            string fileName = "fractions.json";
//            File.WriteAllText(fileName, json);
//            Console.WriteLine($"\nМасив дробів збережено у файл: {fileName}");

//            // 4 Завантаження та десеріалізація з файлу
//            if (File.Exists(fileName))
//            {
//                string loadedJson = File.ReadAllText(fileName);
//                List<Fraction> loadedFractions = JsonSerializer.Deserialize<List<Fraction>>(loadedJson);

//                Console.WriteLine("\nЗавантажені дроби з файлу:");
//                foreach (var frac in loadedFractions)
//                {
//                    Console.WriteLine("  " + frac);
//                }
//            }
//            else
//            {
//                Console.WriteLine("Файл не знайдено!");
//            }

//            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
//            Console.ReadKey();
//        }
//    }
//}
