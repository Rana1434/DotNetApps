using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpLib
{
    public class EmpUtils
    {
        public static List<Employee> EmpDB { get; set; } =new List<Employee>();
        public static int EmpCount { get; set; }
        public static void log<T>(T[] pValues)
        {
            string result = ";";
            foreach (var item in pValues)
            {
                result = $"{result}{item}";
            }

            var finalResult = $"[{DateTime.Now.ToString()}]:{result}";
            //console logging
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------");
            Console.WriteLine(finalResult);

            ///output window
            Debug.WriteLine("------LOG------");
            Debug.WriteLine(finalResult);
        }

    }
}
