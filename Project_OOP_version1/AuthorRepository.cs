using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP_version1
{
        public class AuthorRepository
        {
            private string _filePath = "authors.txt";

            // Завантаження авторів з текстової бази даних
            public List<Author> LoadAuthors()
            {
                List<Author> list = new List<Author>();
        
                if (!File.Exists(_filePath))
                {
                    File.WriteAllLines(_filePath, new string[] { "Ярослав;yar.owner@specter.com" });
                }

                string[] lines = File.ReadAllLines(_filePath);
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split(';');
                    if (parts.Length == 2)
                    {
                        list.Add(new Author(parts[0], parts[1]));
                    }
                }
                return list;
            }

            // Збереження поточного списку авторів у файл
            public void SaveAuthors(List<Author> authors)
            {
                List<string> lines = new List<string>();
                foreach (Author author in authors)
                {
                    lines.Add($"{author.Name};{author.Email}");
                }
                File.WriteAllLines(_filePath, lines);
            }

            // Виведення списку авторів у консоль
            public void PrintAllAuthors(List<Author> authors)
            {
                Console.WriteLine("\n=== ЗБЕРЕЖЕНІ АВТОРИ В БАЗІ ДАНИХ ===");
                if (authors.Count == 0)
                {
                    Console.WriteLine("База даних авторів порожня.");
                    return;
                }

                for (int i = 0; i < authors.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {authors[i].Name} ({authors[i].Email})");
                }
                Console.WriteLine("=====================================\n");
            }
        }
}
