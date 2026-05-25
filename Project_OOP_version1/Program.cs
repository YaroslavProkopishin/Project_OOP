using Project_OOP_version1;
using System;

namespace Project_OOP_version1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== СТАРТАП-ПЛАТФОРМА: ВЕРСІЯ 1.0 (Створення команди) ===\n");

            Author projectAuthor = new Author("Ярослав", "yar.owner@specter.com");
            Console.WriteLine($"[ПРОЦЕС] Зареєстровано автора стартапу: {projectAuthor.Name} ({projectAuthor.Email})");

            Team startupTeam = new Team();

            TeamMember dev = new TeamMember("Олексій", "Lead Backend Developer");
            TeamMember designer = new TeamMember("Дмитро", "UI/UX Designer");
            TeamMember marketer = new TeamMember("Анна", "Growth Marketer");

            startupTeam.AddMember(dev);
            startupTeam.AddMember(designer);
            startupTeam.AddMember(marketer);

            startupTeam.PrintTeamInfo();

            Console.ReadLine();
        }
    }
}