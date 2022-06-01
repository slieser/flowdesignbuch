using System;
using System.Collections.Generic;
using System.Linq;

namespace loccount
{
    public class Ui
    {
        public static void Show(IEnumerable<LOCstat> locStats) {
            foreach (var locStat in locStats) {
                Console.WriteLine($"{locStat.Filename} {locStat.Total} {locStat.Loc}");
            }
            Console.WriteLine();            
            Console.WriteLine("Sum:");            
            Console.WriteLine($"  Total: {locStats.Sum(l => l.Total)}");            
            Console.WriteLine($"  LOC:   {locStats.Sum(l => l.Loc)}");            
        }
    }
}