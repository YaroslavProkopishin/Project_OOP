using System;
using System.Collections.Generic;

namespace Project_OOP_version1
{
    public class StartupPlatformManager
    {
        private Project _currentProject = null;

        // Метод для Пункту 1: Склад команди
        public void ShowTeamInfo(Team team, Author author) => team.PrintTeamInfo();

        // Метод для Пункту 2: Додати фахівця
        public void AddTeamMember(Team team)
        {
            Console.Write("Введіть ім'я фахівця: "); string name = Console.ReadLine();
            Console.Write("Введіть роль: "); string role = Console.ReadLine();
            team.AddMember(new TeamMember(name, role));
        }

        // Метод для Пункту 3: Ініціювати проект
        public void InitiateProject(Author author, Team team)
        {
            _currentProject = new Project(author, team);
            Console.WriteLine($"[ПРОЦЕС] Проект ініційовано автором {author.Name}. Статус: [{_currentProject.Status}].\n");
        }

        // Метод для Пункту 4: Створити ідею та аналіз
        public void CreateAndAnalyzeIdea()
        {
            if (_currentProject == null) { Console.WriteLine(Messages.AccessDenied + "\n"); return; }
            Console.Write("Назва стартапу: "); string title = Console.ReadLine();
            Console.Write("Опис ідеї: "); string desc = Console.ReadLine();
            Console.Write("Попит (1-10): "); int demand = int.Parse(Console.ReadLine());
            Console.Write("Складність (1-10): "); int complexity = int.Parse(Console.ReadLine());
            Console.Write("Вигода (1-10): "); int gain = int.Parse(Console.ReadLine());

            StartupIdea idea = new StartupIdea(title, desc, demand, complexity, gain);
            _currentProject.SetIdea(idea);
            _currentProject.AnalyzeFeasibility();
        }

        // Метод для Пункту 5: Побудова Canvas
        public void DevelopCanvasModel()
        {
            if (_currentProject == null || _currentProject.Idea == null) { Console.WriteLine("[ЗАБОРОНА] Спочатку проаналізуйте ідею.\n"); return; }
            if (_currentProject.Status == "Ідею відхилено") { Console.WriteLine("[ЗАБОРОНА] Ідею відхилено, процес заблоковано.\n"); return; }

            Console.Write("Ціннісна пропозиція: "); string vp = Console.ReadLine();
            Console.Write("Цільова аудиторія: "); string ta = Console.ReadLine();
            Console.Write("Канали збуту: "); string ch = Console.ReadLine();
            Console.Write("Джерела доходів: "); string rs = Console.ReadLine();

            _currentProject.DevelopCanvas(new BusinessModelCanvas(vp, ta, ch, rs));
            _currentProject.Canvas.PrintCanvas();
        }

        // Метод для Пункту 6: Фінансовий план
        public void CreateFinancialPlan()
        {
            if (_currentProject == null || _currentProject.Canvas == null) { Console.WriteLine("[ЗАБОРОНА] Спочатку побудуйте бізнес-модель Canvas.\n"); return; }

            Console.Write("Бюджет на розробку продукту (EUR): "); double dev = double.Parse(Console.ReadLine());
            Console.Write("Бюджет на маркетинг (EUR): "); double market = double.Parse(Console.ReadLine());
            Console.Write("Прогнозований чистий дохід на місяць (EUR): "); double revenue = double.Parse(Console.ReadLine());

            _currentProject.DevelopBusinessPlan(new BusinessPlan(dev, market, revenue));
            _currentProject.FinancialPlan.PrintBusinessPlan();
        }

        // Метод для Пункту 7: Пітчинг інвесторам
        public void PitchToInvestors(Investor[] investors)
        {
            if (_currentProject == null || _currentProject.FinancialPlan == null) { Console.WriteLine("[ЗАБОРОНА] Спочатку розрахуйте бізнес-план з цифрами.\n"); return; }
            Console.WriteLine("[ПОШУК] Запуск презентацій для бази інвесторів...");
            for (int i = 0; i < investors.Length; i++)
            {
                if (_currentProject.PitchProject(investors[i])) break;
            }
        }

        // Метод для Пункту 10: Додати автора в БД
        public void AddNewAuthor(AuthorRepository repo, List<Author> list)
        {
            Console.Write("Введіть ім'я нового автора: "); string name = Console.ReadLine();
            Console.Write("Введіть email автора: "); string email = Console.ReadLine();
            list.Add(new Author(name, email));
            repo.SaveAuthors(list);
            Console.WriteLine($"[БД] Автора {name} успішно додано та збережено у файл!\n");
        }

        // Метод для Пункту 11: Видалити автора з БД
        public void RemoveAuthor(AuthorRepository repo, List<Author> list, ref Author current)
        {
            repo.PrintAllAuthors(list);
            if (list.Count == 0) return;

            Console.Write("Введіть номер автора для видалення: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                index--;
                if (index >= 0 && index < list.Count)
                {
                    string removedName = list[index].Name;
                    list.RemoveAt(index);
                    repo.SaveAuthors(list);
                    Console.WriteLine($"[БД] Автора {removedName} успішно видалено з бази даних.\n");
                    if (list.Count > 0) current = list[0];
                }
                else Console.WriteLine("[ПОМИЛКА] Невірний номер автора.\n");
            }
            else Console.WriteLine("[ПОМИЛКА] Будь ласка, введіть число.\n");
        }

        public void RunFullSimulation()
        {
            Console.WriteLine(Messages.SimulationStart);
            Author author = new Author("Ярослав", "yar.owner@specter.com");
            Team team = new Team();
            team.AddMember(new TeamMember("Олексій", "Lead Backend Dev"));
            team.AddMember(new TeamMember("Дмитро", "UI/UX Designer"));
            team.AddMember(new TeamMember("Анна", "Growth Marketer"));
            team.PrintTeamInfo();

            Project project = new Project(author, team);
            StartupIdea idea = new StartupIdea("Specter Traffic Automation", "Платформа для інтелектуального управління...", 9, 4, 8);
            project.SetIdea(idea);

            if (!project.AnalyzeFeasibility()) return;

            BusinessModelCanvas canvas = new BusinessModelCanvas("Автоматизація закупівлі трафіку", "Арбітражні команди", "Telegram-спільноти", "SaaS");
            project.DevelopCanvas(canvas);
            project.Canvas.PrintCanvas();

            BusinessPlan plan = new BusinessPlan(8000, 4500, 3500);
            project.DevelopBusinessPlan(plan);
            project.FinancialPlan.PrintBusinessPlan();

            Investor fund = new Investor("Венчурний Фонд 'Specter Cap'", 100000, 36);
            project.PitchProject(fund);
            Console.WriteLine(Messages.SimulationEnd);
        }
    }
}