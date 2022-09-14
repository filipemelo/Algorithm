namespace Algorithm.Dynamic_Programming
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/coin-change/problem
    /// Given an amount and the denominations of coins available, determine how many ways change can be made for amount. There is a limitless supply of each coin type.
    /// Example
    /// There are 3 ways to make change for n = 3: {1,1,1}, {1,2} and {3}.
    /// </summary>
    internal class CoinChangeProblem
    {
        public static long GetWays(int n, List<long> coins, bool debug = false)
        {
            var ways = new long[n + 1];
            ways[0] = 1;

            foreach (var coin in coins)
            {
                if (coin > n) continue;

                for (int i = 1; i < ways.Length; i++)
                {
                    if (i >= coin)
                    {
                        ways[i] += ways[i - coin];
                    }
                }
            }

            return ways[n];
        }

        public static void Run()
        {
            var bag = new List<long>[] {  // result:
                new List<long>{ 8, 3, 2, 1 },   // 3
                new List<long>{ 1, 2, 3 },      // 4
                new List<long>{ 2, 5, 3, 6 },   // 5
            };

            var amounts = new int[] { 3, 4, 10 };

            int i = 0;
            for (int j = 0; j < bag.Length; j++)
            {
                var coins = bag[i];
                var result = GetWays(amounts[i++], coins);
                SharedKernel.WriteList(coins);
                Console.WriteLine($"- {result}");
            }
        }
    }
}
