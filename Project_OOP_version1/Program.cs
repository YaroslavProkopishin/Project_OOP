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

            // Ініціалізація бази даних авторів
            AuthorRepository authorRepo = new AuthorRepository();
            List<Author> dbAuthors = authorRepo.LoadAuthors();

            // Поточний автор за замовчуванням (перший з бази)
            Author currentAuthor = dbAuthors.Count > 0 ? dbAuthors[0] : new Author("Ярослав", "yar.owner@specter.com");

            Team team = new Team();
            Project currentProject = null;

            Investor[] investors = new Investor[2]
            {
                new Investor("Ангел-Інвестор (Максим)", 5000, 12),
                new Investor("Венчурний Фонд 'Specter Cap'", 100000, 36)
            };

            bool running = true;
            while (running)
            {
                Console.WriteLine("ДОСТУПНІ ДІЇ:");
                Console.WriteLine(Messages.MenuAction1);
                Console.WriteLine(Messages.MenuAction2);
                Console.WriteLine(Messages.MenuAction3);
                Console.WriteLine(Messages.MenuAction4);
                Console.WriteLine(Messages.MenuAction5);
                Console.WriteLine(Messages.MenuAction6);
                Console.WriteLine(Messages.MenuAction7);
                Console.WriteLine(Messages.MenuAction8);
                Console.WriteLine(Messages.MenuAction9); 
                Console.WriteLine(Messages.MenuAction10);  
                Console.WriteLine(Messages.MenuAction11);  
                Console.WriteLine(Messages.MenuAction12);  

                Console.Write("\n" + Messages.EnterChoice);

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": team.PrintTeamInfo(); break;
                    case "2":
                        Console.Write("Введіть ім'я фахівця: "); string name = Console.ReadLine();
                        Console.Write("Введіть роль: "); string role = Console.ReadLine();
                        team.AddMember(new TeamMember(name, role));
                        break;
                    case "3":
                        currentProject = new Project(currentAuthor, team);
                        Console.WriteLine($"[ПРОЦЕС] Проект ініційовано автором {currentAuthor.Name}. Статус: [{currentProject.Status}].\n");
                        break;
                    case "4":
                        if (currentProject == null) { Console.WriteLine(Messages.AccessDenied + "\n"); break; }
                        Console.Write("Назва стартапу: "); string title = Console.ReadLine();
                        Console.Write("Опис ідеї: "); string desc = Console.ReadLine();
                        Console.Write("Попит (1-10): "); int demand = int.Parse(Console.ReadLine());
                        Console.Write("Складність (1-10): "); int complexity = int.Parse(Console.ReadLine());
                        Console.Write("Вигода (1-10): "); int gain = int.Parse(Console.ReadLine());

                        StartupIdea idea = new StartupIdea(title, desc, demand, complexity, gain);
                        currentProject.SetIdea(idea);
                        currentProject.AnalyzeFeasibility();
                        break;
                    case "5":
                        if (currentProject == null || currentProject.Idea == null) { Console.WriteLine("[ЗАБОРОНА] Спочатку проаналізуйте ідею (Пункт 4).\n"); break; }
                        if (currentProject.Status == "Ідею відхилено") { Console.WriteLine("[ЗАБОРОНА] Ідею відхилено, процес заблоковано.\n"); break; }

                        Console.Write("Ціннісна пропозиція: "); string vp = Console.ReadLine();
                        Console.Write("Цільова аудиторія: "); string ta = Console.ReadLine();
                        Console.Write("Канали збуту: "); string ch = Console.ReadLine();
                        Console.Write("Джерела доходів: "); string rs = Console.ReadLine();

                        currentProject.DevelopCanvas(new BusinessModelCanvas(vp, ta, ch, rs));
                        currentProject.Canvas.PrintCanvas();
                        break;
                    case "6":
                        if (currentProject == null || currentProject.Canvas == null) { Console.WriteLine("[ЗАБОРОНА] Спочатку побудуйте бізнес-модель Canvas (Пункт 5).\n"); break; }

                        Console.Write("Бюджет на розробку продукту (EUR): "); double dev = double.Parse(Console.ReadLine());
                        Console.Write("Бюджет на маркетинг (EUR): "); double market = double.Parse(Console.ReadLine());
                        Console.Write("Прогнозований чистий дохід на місяць (EUR): "); double revenue = double.Parse(Console.ReadLine());

                        currentProject.DevelopBusinessPlan(new BusinessPlan(dev, market, revenue));
                        currentProject.FinancialPlan.PrintBusinessPlan();
                        break;

                    case "7":
                        if (currentProject == null || currentProject.FinancialPlan == null) { Console.WriteLine("[ЗАБОРОНА] Спочатку розрахуйте бізнес-план з цифрами (Пункт 6).\n"); break; }
                        Console.WriteLine("[ПОШУК] Запуск презентацій для бази інвесторів...");
                        for (int i = 0; i < investors.Length; i++)
                        {
                            if (currentProject.PitchProject(investors[i])) break;
                        }
                        break;

                    case "8":
                        StartupPlatformManager simulation = new StartupPlatformManager();
                        simulation.RunFullSimulation();
                        break;

                  
                    case "9":
                        authorRepo.PrintAllAuthors(dbAuthors);
                        break;

                  
                    case "10":
                        Console.Write("Введіть ім'я нового автора: "); string aName = Console.ReadLine();
                        Console.Write("Введіть email автора: "); string aEmail = Console.ReadLine();

                        dbAuthors.Add(new Author(aName, aEmail));
                        authorRepo.SaveAuthors(dbAuthors);
                        Console.WriteLine($"[БД] Автора {aName} успішно додано та збережено у файл!\n");
                        break;

                    
                    case "11":
                        authorRepo.PrintAllAuthors(dbAuthors);
                        if (dbAuthors.Count == 0) break;

                        Console.Write("Введіть номер автора для видалення: ");
                        string input = Console.ReadLine();
                        int index;

                        if (int.TryParse(input, out index))
                        {
                            index--;
                            if (index >= 0 && index < dbAuthors.Count)
                            {
                                string removedName = dbAuthors[index].Name;
                                dbAuthors.RemoveAt(index);
                                authorRepo.SaveAuthors(dbAuthors);
                                Console.WriteLine($"[БД] Автора {removedName} успішно видалено з бази даних.\n");

                                if (dbAuthors.Count > 0) currentAuthor = dbAuthors[0];
                            }
                            else
                            {
                                Console.WriteLine("[ПОМИЛКА] Невірний номер автора.\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("[ПОМИЛКА] Будь ласка, введіть число.\n");
                        }
                        break;

                 
                    case "12": running = false; break;
                    default: Console.WriteLine("Невірний вибір.\n"); break;
                }
                Console.WriteLine("--------------------------------------------------");
            }
        }
    }
}