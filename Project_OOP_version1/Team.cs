using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP_version1
{
    public class Team
    {
        private TeamMember[] _members = new TeamMember[10];
        private int _memberCount = 0;

        public void AddMember(TeamMember member)
        {
            if (_memberCount >= _members.Length)
            {
                Console.WriteLine($"[ПОМИЛКА] Ліміт команди вичерпано!");
                return;
            }
            _members[_memberCount] = member;
            _memberCount++;
            Console.WriteLine($"До команди додано: {member.Name} на позицію [{member.Role}].");
        }

        public void PrintTeamInfo()
        {
            Console.WriteLine("\n=========================================");
            Console.WriteLine("        ПОТОЧНИЙ СКЛАД КОМАНДИ           ");
            Console.WriteLine("=========================================");
            if (_memberCount == 0)
            {
                Console.WriteLine("Команда ще порожня.");
                return;
            }
            for (int i = 0; i < _memberCount; i++)
            {
                Console.WriteLine($" -> {_members[i].Name} — {_members[i].Role}");
            }
            Console.WriteLine("=========================================\n");
        }
    }
}
