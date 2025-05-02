using System;
using System.Collections.Generic;
using System.Linq;

namespace loccount
{
    public class Ui
    {
        public static void Show(IEnumerable<FileInfo> fileInfos) {
            foreach (var fileInfo in fileInfos) {
                Console.WriteLine($"{fileInfo.Filename} {fileInfo.Total} {fileInfo.Loc}");
            }
            Console.WriteLine();            
            Console.WriteLine("Sum:");            
            Console.WriteLine($"  Total: {fileInfos.Sum(l => l.Total)}");            
            Console.WriteLine($"  LOC:   {fileInfos.Sum(l => l.Loc)}");            
        }
    }
}