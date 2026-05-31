using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP_version1
{
    public class Project
    {
        public Author ProjectAuthor { get; private set; }
        public Team ProjectTeam { get; private set; }
        public StartupIdea Idea { get; private set; }


        public string Status { get; private set; }

        public Project(Author author, Team team)
        {
            ProjectAuthor = author;
            ProjectTeam = team;
            Status = "Команда сформована";
        }


        public void SetIdea(StartupIdea idea)
        {
            Idea = idea;
            Status = "Ідея на аналізі";
            Console.WriteLine($" До проекту додано ідею: \"{Idea.Title}\"");
        }

        // Алгоритм аналізу доцільності ідеї (Задача 2)
        public bool AnalyzeFeasibility()
        {
            if (Idea == null)
            {
                Console.WriteLine("[ПОМИЛКА] Неможливо провести аналіз: ідея ще не додана в проект.");
                return false;
            }

            Console.WriteLine("\n[АНАЛІЗ] Запуск тестування життєздатності ідеї...");
            Console.WriteLine($" -> Актуальність ринку: {Idea.MarketDemand}/10");
            Console.WriteLine($" -> Складність розробки: {Idea.TechComplexity}/10");
            Console.WriteLine($" -> Фінансова вигода: {Idea.FinancialGain}/10");

            // Формула доцільності: (Попит + Вигода) - Складність
            int score = (Idea.MarketDemand + Idea.FinancialGain) - Idea.TechComplexity;

            if (score >= 5)
            {
                Status = "Проект схвалено до реалізації";
                Console.WriteLine($"[ВЕРДИКТ] Успіх! Оцінка проекту: {score}. Ідея доцільна. Переходимо до бізнес-моделювання.\n");
                return true;
            }
            else
            {
                Status = "Ідею відхилено";
                Console.WriteLine($"[ВЕРДИКТ] Відмова. Оцінка проекту: {score}. Ризики занадто високі, ідея недоцільна.\n");
                return false;
            }
        }

        public BusinessModelCanvas Canvas { get; private set; }

        public void DevelopCanvas(BusinessModelCanvas canvas)
        {
            if (Status == "Ідею відхилено" || Idea == null)
            {
                Console.WriteLine("[ЗАБОРОНА] Не можна розробляти бізнес-модель для нерентабельної або відсутньої ідеї!");
                return;
            }

            Canvas = canvas;
            Status = "Бізнес-модель побудована";
            Console.WriteLine($"[ПРОЦЕС] Бізнес-модель Canvas для проекту \"{Idea.Title}\" успішно сформована та інтегрована.");
        }

        public BusinessPlan FinancialPlan { get; private set; }


        public void DevelopBusinessPlan(BusinessPlan plan)
        {

            if (Canvas == null)
            {
                Console.WriteLine("[ЗАБОРОНА] Не можна розробляти бізнес-план без готової Canvas моделі!");
                return;
            }

            FinancialPlan = plan;
            Status = "Бізнес-план розроблено";
            Console.WriteLine($"[ПРОЦЕС] Фінансовий бізнес-план для проекту успішно прораховано та затверджено.");
        }

        public bool PitchProject(Investor investor)
        {
            if (FinancialPlan == null)
            {
                Console.WriteLine("[ЗАБОРОНА] Не можна проводити презентацію! Спочатку розробіть фінансовий бізнес-план (Пункт 6).");
                return false;
            }

            Console.WriteLine($"\n[ПІТЧИНГ] Презентація проекту \"{Idea.Title}\" перед інвестором: {investor.Name}...");
            Console.WriteLine($" -> Вимоги інвестора: Бюджет до {investor.MaxInvestmentBudget} EUR, Окупність до {investor.MaxAllowedPaybackMonths} міс.");
            Console.WriteLine($" -> Показники стартапу: Треба {FinancialPlan.TotalInvestmentNeeded} EUR, Окупність {FinancialPlan.PaybackPeriodMonths} міс.");

            // Перевірка умов інвестора за бюджетом
            if (FinancialPlan.TotalInvestmentNeeded > investor.MaxInvestmentBudget)
            {
                Console.WriteLine($"[ВІДМОВА] {investor.Name}: \"Проект занадто дорогий для мого портфеля.\"");
                return false;
            }

            // Перевірка умов за окупністю
            if (FinancialPlan.PaybackPeriodMonths > investor.MaxAllowedPaybackMonths)
            {
                Console.WriteLine($"[ВІДМОВА] {investor.Name}: \"Термін окупності занадто великий. Це високі ризики.\"");
                return false;
            }

            Status = "Фінансування отримано";
            Console.WriteLine($"\n==================================================");
            Console.WriteLine($"[УСПІХ] Інвестор {investor.Name} СХВАЛИВ проект!");
            Console.WriteLine($"Контракт підписано. Виділено фінансування: {FinancialPlan.TotalInvestmentNeeded} EUR.");
            Console.WriteLine("==================================================\n");
            return true;
        }
    }
}
