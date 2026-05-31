using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP_version1
{
    public class StartupPlatformManager
    {
        public void RunFullSimulation()
        {
            Console.WriteLine("\n==================================================");
            Console.WriteLine("    ЗАПУСК ПОВНОГО АВТОМАТИЗОВАНОГО ЦИКЛУ СТАРТАПУ  ");
            Console.WriteLine("==================================================\n");


            Author author = new Author("Ярослав", "yar.owner@specter.com");
            Team team = new Team();
            team.AddMember(new TeamMember("Олексій", "Lead Backend Dev"));
            team.AddMember(new TeamMember("Дмитро", "UI/UX Designer"));
            team.AddMember(new TeamMember("Анна", "Growth Marketer"));
            team.PrintTeamInfo();


            Project project = new Project(author, team);
            StartupIdea idea = new StartupIdea(
                "Specter Traffic Automation",
                "Платформа для інтелектуального управління та перенаправлення трафіку",
                9, // Попит на ринку
                4, // Технічна складність
                8  // Фінансова вигода
            );
            project.SetIdea(idea);

            if (!project.AnalyzeFeasibility())
            {
                Console.WriteLine("[ЗУПИНКА] Автоматичний цикл перервано: ідея недоцільна.");
                return;
            }

            BusinessModelCanvas canvas = new BusinessModelCanvas(
                "Оптимізація та автоматизація закупівлі трафіку під ключ",
                "Арбітражні команди, медіабаєри, інтернет-маркетологи",
                "Профільні медіа, Telegram-спільноти, рекомендації",
                "SaaS-підписка (щомісячна плата), % від зекономленого бюджету"
            );
            project.DevelopCanvas(canvas);
            project.Canvas.PrintCanvas();


            BusinessPlan plan = new BusinessPlan(8000, 4500, 3500);
            project.DevelopBusinessPlan(plan);
            project.FinancialPlan.PrintBusinessPlan();

            Investor fund = new Investor("Венчурний Фонд 'Specter Cap'", 100000, 36);
            project.PitchProject(fund);

            Console.WriteLine("==================================================");
            Console.WriteLine("       АВТОМАТИЧНУ СИМУЛЯЦІЮ УСПІШНО ЗАВЕРШЕНО      ");
            Console.WriteLine("==================================================\n");
        }
    }
}
