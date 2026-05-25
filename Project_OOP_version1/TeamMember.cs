using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP_version1
{
    public class TeamMember
    {
        public string Name { get; private set; }
        public string Role { get; private set; }

        public TeamMember(string name, string role)
        {
            Name = name;
            Role = role;
        }
    }
}
