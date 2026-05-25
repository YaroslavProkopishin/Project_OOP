using System;

namespace Project_OOP_version1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== СТАРТАП-ПЛАТФОРМА: ВЕРСІЯ 2.0 (Керовані процеси) ===\n");

            Author author = new Author("Ярослав", "yar.owner@specter.com");
            Team team = new Team();
            Project currentProject = null;

            bool running = true;
            while (running)
            {
                Console.WriteLine("ДОСТУПНІ ДІЇ:");
                Console.WriteLine("1. Переглянути склад команди");
                Console.WriteLine("2. Додати фахівця до команди (вручну)");
                Console.WriteLine("3. Ініціювати проект (об'єднати Автора та Команду)");
                Console.WriteLine("4. Створити стартап-ідею та запустити аналіз доцільності");
                Console.WriteLine("5. Вихід");
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
                        Console.Write("Введіть роль (напр., Developer, Designer, Marketer): ");
                        string role = Console.ReadLine();

                        team.AddMember(new TeamMember(name, role));
                        break;

                    case "3":
                        currentProject = new Project(author, team);
                        Console.WriteLine($" Проект успішно ініційовано автором {author.Name}. Поточний статус: [{currentProject.Status}].\n");
                        break;

                    case "4":
                        if (currentProject == null)
                        {
                            Console.WriteLine("[ЗАБОРОНА] Помилка бізнес-процесу! Спочатку потрібно ініціювати проект (Пункт 3)!\n");
                            break;
                        }

                        Console.WriteLine("[ГЕНЕРАЦІЯ] Введіть параметри вашої ідеї:");
                        Console.Write("Назва стартапу: ");
                        string title = Console.ReadLine();
                        Console.Write("Опис ідеї: ");
                        string desc = Console.ReadLine();

                        Console.Write("Оцініть попит на ринку (1-10): ");
                        int demand = int.Parse(Console.ReadLine());
                        Console.Write("Оцініть технічну складність розробки (1-10): ");
                        int complexity = int.Parse(Console.ReadLine());
                        Console.Write("Оцініть потенційну фінансову вигоду (1-10): ");
                        int gain = int.Parse(Console.ReadLine());

                        StartupIdea idea = new StartupIdea(title, desc, demand, complexity, gain);

                        currentProject.SetIdea(idea);
                        currentProject.AnalyzeFeasibility();
                        break;

                    case "5":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.\n");
                        break;
                }
            }
        }
    }
}