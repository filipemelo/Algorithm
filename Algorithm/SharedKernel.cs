using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    internal static class SharedKernel
    {
        internal static void WriteList<T>(IEnumerable<T> list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
