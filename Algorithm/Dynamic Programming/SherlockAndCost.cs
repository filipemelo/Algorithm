using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Dynamic_Programming
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/sherlock-and-cost/problem
    /// In this challenge, you will be given an array B and must determine an array A. 
    /// There is a special rule: For all i, A[i] <= B[i]. 
    /// That is A[i] can be any number you choose such that 1 <= A[i] <= B[i]. 
    /// Your task is to select a series of A[i] given B[i] such that the sum of the absolute difference of consecutive pairs of A is maximized. 
    /// This will be the array's cost, and will be represented by the variable S below.
    /// The equation can be written:
    /// S = MAX( ABS(A[i] - A[i-1] ) where i > 2.
    /// For example, if the array B[1, 2, 3], we know that 1<= A[1] <= 1, 1 <= A[2] <= 2 and  1 <= A[3] <= 3. 
    /// A can be:
    /// [1,1,1], [1,1,2], [1,1,3]
    /// [1,2,1], [1,2,2], [1,2,3]
    /// Calculating:
    /// |1-1| + |1-1| = 0	|1-1| + |2-1| = 1	|1-1| + |3-1| = 2
    /// |2-1| + |1-2| = 2	|2-1| + |2-2| = 1	|2-1| + |3-2| = 2
    /// The maximum value obtained is 2.
    /// </summary>
    internal class SherlockAndCost
    {
        static int Cost(int n1, int n2)
        {
            return Math.Abs(n1 - n2);
        }

        public static int MaxCost(List<int> B)
        {
            var S1 = 0;
            var S2 = 0;

            for (int i = 1; i < B.Count; i++)
            {
                // For Example A[i] = 100 and A[i-1] = 100
                // S1 => comes from Any Value(Max or 1), Max
                // S2 => comes from Any Value(Max or 1), 1

                // S1 + | A[i] - A[i-1] | => 100, 100
                var newS1Max = Cost(B[i], B[i - 1]) + S1;
                // S2 + | A[i] - 1 |  => (A[i-1] == 1)  => 100, 1
                var newS1Min = Cost(B[i], 1) + S2;
                // Max of S1 (newS1Max, newS1Min)
                var newS1 = Math.Max(newS1Max, newS1Min);
                // S1 + | 1 - A[i-1] | => (A[i] == 1) => 1, 100
                var newS2Max = Cost(1, B[i - 1]) + S1;
                // S2 + | 1 - 1 | = 0 => 1, 1
                var newS2Min = S2;
                // Max of S2 (newS2Max, newS2Min)
                var newS2 = Math.Max(newS2Max, newS2Min);

                S1 = newS1;
                S2 = newS2;
            }

            var S = Math.Max(S1, S2);
            return S;
        }

        internal static void Run()
        {
            var Bs = new List<int>[] {                  // result:
                new List<int> { 1, 2, 3 },              // 2
                new List<int> { 10, 1, 10, 1, 10 },     // 36
                new List<int> { 10, 2, 10, 2, 10 },     // 36
                new List<int> { 10, 1, 1, 10, 1, 10 }   // 36
            };

            for (int i = 0; i < Bs.Length; i++)
            {
                var B = Bs[i];
                var result = MaxCost(Bs[i]);
                SharedKernel.WriteList(B);
                Console.WriteLine($"- {result}");
            }
        }
    }
}
