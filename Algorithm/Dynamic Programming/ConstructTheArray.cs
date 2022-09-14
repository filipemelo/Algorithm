using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Dynamic_Programming
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/construct-the-array/problem
    /// Your goal is to find the number of ways to construct an array such that consecutive positions contain different values.
    /// Specifically, we want to construct an array with n elements such that each element between 1 and k inclusive. 
    /// We also want the first and last elements of the array to be 1 and x.
    /// Given n, k and x find the number of ways to construct such an array. Since the answer may be large, only find it modulo 10^9 + 7.
    /// For example, for n=4, k=3, x=2, there are 3 ways, as shown here:
    ///  1 ------ x (x=2)
    /// [1, 2, 1, 2]
    /// [1, 2, 3, 2]
    /// [1, 3, 1, 2]
    ///     k, k    (k=3)
    /// 4 elements (n=4)
    /// Complete the function countArray which takes input n, k and x. Return the number of ways to construct the array such that consecutive elements are distinct.
    /// </summary>
    internal class ConstructTheArray
    {
        public static long CountArray(int n, int k, int x) {
            const long MOD = 1_000_000_007;
            var a = new long[n];
            var b = new long[n];

            a[0] = x == 1 ? 1 : 0;
            b[0] = x == 1 ? 0 : 1;

            for (int i = 1; i < n; i++) {
                a[i] = b[i - 1] % MOD;
                b[i] = (a[i - 1] * (k - 1) + b[i - 1] * (k - 2)) % MOD;
            }

            return a[n-1];
        }

        internal static void Run()
        {
            var result = CountArray(4, 3, 2);
            Console.WriteLine(result);
        }
    }
}
