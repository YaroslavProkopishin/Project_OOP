using System;

namespace Project_OOP_version1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== СТАРТАП-ПЛАТФОРМА: ВЕРСІЯ 3.0 (Моделювання Canvas) ===\n");

            Author author = new Author("Ярослав", "yar.owner@specter.com");
            Team team = new Team();
            Project currentProject = null;

            bool running = true;
            while (running)
            {
                Console.WriteLine("ДОСТУПНІ ДІЇ:");
                Console.WriteLine("1. Переглянути склад команди");
                Console.WriteLine("2. Додати фахівця до команди");
                Console.WriteLine("3. Ініціювати проект (об'єднати Автора та Команду)");
                Console.WriteLine("4. Створити стартап-ідею та запустити аналіз доцільності");
                Console.WriteLine("5. Розробити бізнес-модель Canvas");
                Console.WriteLine("6. Вихід");
                Console.Write("\nОберіть дію: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        team.PrintTeamInfo();
                        break;

                    case "2":
                        Console.Write("Введіть ім'я фахівця: ");
                        string name = Console.ReadLine();
                        Console.Write("Введіть роль: ");
                        string role = Console.ReadLine();
                        team.AddMember(new TeamMember(name, role));
                        break;

                    case "3":
                        currentProject = new Project(author, team);
                        Console.WriteLine($"[ПРОЦЕС] Проект успішно ініційовано. Статус: [{currentProject.Status}].\n");
                        break;

                    case "4":
                        if (currentProject == null)
                        {
                            Console.WriteLine("[ЗАБОРОНА] Спочатку потрібно ініціювати проект (Пункт 3)!\n");
                            break;
                        }

                        Console.WriteLine("[ГЕНЕРАЦІЯ] Введіть параметри ідеї:");
                        Console.Write("Назва стартапу: ");
                        string title = Console.ReadLine();
                        Console.Write("Опис ідеї: ");
                        string desc = Console.ReadLine();
                        Console.Write("Попит на ринку (1-10): ");
                        int demand = int.Parse(Console.ReadLine());
                        Console.Write("Технічна складність (1-10): ");
                        int complexity = int.Parse(Console.ReadLine());
                        Console.Write("Фінансова вигода (1-10): ");
                        int gain = int.Parse(Console.ReadLine());

                        StartupIdea idea = new StartupIdea(title, desc, demand, complexity, gain);
                        currentProject.SetIdea(idea);
                        currentProject.AnalyzeFeasibility();
                        break;

                    case "5":
                        // ВАЛІДАЦІЯ БІЗНЕС-ПРОЦЕСУ
                        if (currentProject == null || currentProject.Idea == null)
                        {
                            Console.WriteLine("[ЗАБОРОНА] Не можна будувати Canvas! Спочатку завантажте та проаналізуйте ідею (Пункт 4).\n");
                            break;
                        }
                        if (currentProject.Status == "Ідею відхилено")
                        {
                            Console.WriteLine("[ЗАБОРОНА] Процес заблоковано: ваша ідея недоцільна за результатами аналізу.\n");
                            break;
                        }

                        Console.WriteLine("[МОДЕЛЮВАННЯ] Заповнення блоків Canvas:");
                        Console.Write("Яка головна цінність продукту? (Value Proposition): ");
                        string vp = Console.ReadLine();
                        Console.Write("Хто ваша цільова аудиторія? (Target Audience): ");
                        string ta = Console.ReadLine();
                        Console.Write("Які канали залучення клієнтів? (Channels): ");
                        string ch = Console.ReadLine();
                        Console.Write("Які основні джерела доходів? (Revenue Streams): ");
                        string rs = Console.ReadLine();

                        BusinessModelCanvas canvas = new BusinessModelCanvas(vp, ta, ch, rs);
                        currentProject.DevelopCanvas(canvas);


                        currentProject.Canvas.PrintCanvas();
                        break;

                    case "6":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.\n");
                        break;
                }
                Console.WriteLine("--------------------------------------------------\n");
            }
        }
    }
}