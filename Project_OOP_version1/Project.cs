using System;

namespace Project_OOP_version1
{
    public class Project
    {
        public Author ProjectAuthor { get; private set; }
        public Team ProjectTeam { get; private set; }
        public StartupIdea Idea { get; private set; }
        public BusinessModelCanvas Canvas { get; private set; }
        public BusinessPlan FinancialPlan { get; private set; }
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
            Console.WriteLine($"[ПРОЦЕС] До проекту додано ідею: \"{Idea.Title}\"");
        }

        public bool AnalyzeFeasibility()
        {
            if (Idea == null) return false;

            Console.WriteLine("\n[АНАЛІЗ] Запуск тестування життєздатності ідеї...");
            int score = (Idea.MarketDemand + Idea.FinancialGain) - Idea.TechComplexity;

            if (score >= 5)
            {
                Status = "Проект схвалено до реалізації";
                Console.WriteLine($"[ВЕРДИКТ] Оцінка проекту: {score}. Ідея доцільна.\n");
                return true;
            }
            else
            {
                Status = "Ідею відхилено";
                Console.WriteLine($"[ВЕРДИКТ] Оцінка проекту: {score}. Ідея недоцільна.\n");
                return false;
            }
        }

        public void DevelopCanvas(BusinessModelCanvas canvas)
        {
            if (Status == "Ідею відхилено" || Idea == null) return;
            Canvas = canvas;
            Status = "Бізнес-модель побудована";
            Console.WriteLine($"[ПРОЦЕС] Бізнес-модель Canvas для проекту успішно сформована.");
        }

        public void DevelopBusinessPlan(BusinessPlan plan)
        {
            if (Canvas == null)
            {
                Console.WriteLine("[ЗАБОРОНА] Не можна розробляти бізнес-план без готової Canvas модели!");
                return;
            }
            FinancialPlan = plan;
            Status = "Бізнес-план розроблено";
            Console.WriteLine($"[ПРОЦЕС] Фінансовий бізнес-план успішно затверджено.");
        }
    }
}