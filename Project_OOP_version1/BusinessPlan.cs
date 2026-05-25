using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP_version1
{
    public class BusinessPlan
    {
        private double[] _financials = new double[3];

        public double DevelopmentBudget { get { return _financials[0]; } }
        public double MarketingBudget { get { return _financials[1]; } }
        public double ProjectedMonthlyRevenue { get { return _financials[2]; } }

        // Розрахунок загальних інвестицій та окупності
        public double TotalInvestmentNeeded { get { return DevelopmentBudget + MarketingBudget; } }
        public int PaybackPeriodMonths
        {
            get
            {
                if (ProjectedMonthlyRevenue <= 0) return -1; 
                return (int)Math.Ceiling(TotalInvestmentNeeded / ProjectedMonthlyRevenue);
            }
        }

        public BusinessPlan(double devBudget, double marketBudget, double monthlyRevenue)
        {
            _financials[0] = devBudget;
            _financials[1] = marketBudget;
            _financials[2] = monthlyRevenue;
        }

        public void PrintBusinessPlan()
        {
            Console.WriteLine("\n==================================================");
            Console.WriteLine("               ФІНАНСОВИЙ БІЗНЕС-ПЛАН             ");
            Console.WriteLine("==================================================");
            Console.WriteLine($"1. Витрати на розробку (Dev):     {DevelopmentBudget} EUR");
            Console.WriteLine($"2. Маркетинговий бюджет:          {MarketingBudget} EUR");
            Console.WriteLine($"--------------------------------------------------");
            Console.WriteLine($"ЗАГАЛЬНИЙ ОБСЯГ ІНВЕСТИЦІЙ:       {TotalInvestmentNeeded} EUR");
            Console.WriteLine($"Прогнозований дохід (в місяць):   {ProjectedMonthlyRevenue} EUR");
            Console.WriteLine($"Очікуваний термін окупності:      {PaybackPeriodMonths} міс.");
            Console.WriteLine("==================================================");
        }
    }
}
