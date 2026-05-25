using System;

namespace Project_OOP_version1
{
    public class BusinessModelCanvas
    {
        private string[] _blocks = new string[4];

        public string ValueProposition { get { return _blocks[0]; } }
        public string TargetAudience { get { return _blocks[1]; } }
        public string Channels { get { return _blocks[2]; } }
        public string RevenueStreams { get { return _blocks[3]; } }

       
        public BusinessModelCanvas(string valueProposition, string targetAudience, string channels, string revenueStreams)
        {
            _blocks[0] = valueProposition;
            _blocks[1] = targetAudience;
            _blocks[2] = channels;
            _blocks[3] = revenueStreams;
        }

       
        public void PrintCanvas()
        {
            Console.WriteLine("\n==================================================");
            Console.WriteLine("          БІЗНЕС-МОДЕЛЬ CANVAS ПРОЕКТУ            ");
            Console.WriteLine("==================================================");
            Console.WriteLine($"1. ЦІННІСНА ПРОПОЗИЦІЯ: {ValueProposition}");
            Console.WriteLine($"2. ЦІЛЬОВА АУДИТОРІЯ:   {TargetAudience}");
            Console.WriteLine($"3. КАНАЛИ ЗБУТУ:        {Channels}");
            Console.WriteLine($"4. ДЖЕРЕЛА ДОХОДІВ:     {RevenueStreams}");
        }
    }
}