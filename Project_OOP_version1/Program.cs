using System;
using System.Collections.Generic;

namespace Project_OOP_version1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(Messages.MenuTitle + "\n");

            // Ініціалізація інфраструктури розробки та БД
            AuthorRepository authorRepo = new AuthorRepository();
            List<Author> dbAuthors = authorRepo.LoadAuthors();
            Author currentAuthor = dbAuthors.Count > 0 ? dbAuthors[0] : new Author("Ярослав", "yar.owner@specter.com");

            Team team = new Team();
            Investor[] investors = new Investor[2]
            {
                new Investor("Ангел-Інвестор (Максим)", 5000, 12),
                new Investor("Венчурний Фонд 'Specter Cap'", 100000, 36)
            };

          
            StartupPlatformManager manager = new StartupPlatformManager();

            // Масив строк для виведення меню за один прохід циклу for
            string[] menuLabels = new string[]
            {
                Messages.MenuAction1, Messages.MenuAction2, Messages.MenuAction3,
                Messages.MenuAction4, Messages.MenuAction5, Messages.MenuAction6,
                Messages.MenuAction7, Messages.MenuAction8, Messages.MenuAction9,
                Messages.MenuAction10, Messages.MenuAction11, Messages.MenuAction12
            };

            bool running = true;
            while (running)
            {
                Console.WriteLine("ДОСТУПНІ ДІЇ:");

                // Виводимо меню ОДНИМ чистим циклом for
                for (int i = 0; i < menuLabels.Length; i++)
                {
                    Console.WriteLine(menuLabels[i]);
                }

                Console.Write("\n" + Messages.EnterChoice);
                string choice = Console.ReadLine();
                Console.WriteLine();

                
                switch (choice)
                {
                    case "1": manager.ShowTeamInfo(team, currentAuthor); break;
                    case "2": manager.AddTeamMember(team); break;
                    case "3": manager.InitiateProject(currentAuthor, team); break;
                    case "4": manager.CreateAndAnalyzeIdea(); break;
                    case "5": manager.DevelopCanvasModel(); break;
                    case "6": manager.CreateFinancialPlan(); break;
                    case "7": manager.PitchToInvestors(investors); break;
                    case "8": manager.RunFullSimulation(); break;
                    case "9": authorRepo.PrintAllAuthors(dbAuthors); break;
                    case "10": manager.AddNewAuthor(authorRepo, dbAuthors); break;
                    case "11": manager.RemoveAuthor(authorRepo, dbAuthors, ref currentAuthor); break;
                    case "12": running = false; break;
                    default: Console.WriteLine("Невірний вибір.\n"); break;
                }
                Console.WriteLine("--------------------------------------------------");
            }
        }
    }
}