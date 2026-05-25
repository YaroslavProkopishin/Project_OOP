using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP_version1
{
    public class StartupIdea
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        public int MarketDemand { get; private set; }   // Попит
        public int TechComplexity { get; private set; } // складність
        public int FinancialGain { get; private set; }   // прибуток

        public StartupIdea(string title, string description, int marketDemand, int techComplexity, int financialGain)
        {
            Title = title;
            Description = description;
            MarketDemand = marketDemand;
            TechComplexity = techComplexity;
            FinancialGain = financialGain;
        }
    }
}
