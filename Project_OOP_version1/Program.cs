using System;

namespace Project_OOP_version1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== СТАРТАП-ПЛАТФОРМА: ВЕРСІЯ 4.0 (Фінансовий Бізнес-план) ===\n");

            Author author = new Author("Ярослав", "yar.owner@specter.com");
            Team team = new Team();
            Project currentProject = null;

            bool running = true;
            while (running)
            {
                Console.WriteLine("ДОСТУПНІ ДІЇ:");
                Console.WriteLine("1. Переглянути склад команди");
                Console.WriteLine("2. Додати фахівця до команди");
                Console.WriteLine("3. Ініціювати проект");
                Console.WriteLine("4. Створити стартап-ідею та запустити аналіз доцільності");
                Console.WriteLine("5. Розробити бізнес-модель Canvas");
                Console.WriteLine("6. Розрахувати фінансовий бізнес-план");
                Console.WriteLine("7. Вихід");
                Console.Write("\nОберіть дію: ");

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
                        currentProject = new Project(author, team);
                        Console.WriteLine($"Проект ініційовано. Статус: [{currentProject.Status}].\n");
                        break;
                    case "4":
                        if (currentProject == null) { Console.WriteLine("[ЗАБОРОНА] Спочатку ініціюйте проект (Пункт 3)!\n"); break; }
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
                    case "7": running = false; break;
                    default: Console.WriteLine("Невірний вибір.\n"); break;
                }
                Console.WriteLine("--------------------------------------------------");
            }
        }
    }
}