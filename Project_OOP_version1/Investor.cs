using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP_version1
{
    public class Investor
    {
        public string Name { get; private set; }
        public double MaxInvestmentBudget { get; private set; } 
        public int MaxAllowedPaybackMonths { get; private set; }

        public Investor(string name, double maxInvestment, int maxPaybackMonths)
        {
            Name = name;
            MaxInvestmentBudget = maxInvestment;
            MaxAllowedPaybackMonths = maxPaybackMonths;
        }
    }
}
