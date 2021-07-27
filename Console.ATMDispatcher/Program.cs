using System.Collections.Generic;
using System.Linq;

namespace Console.ATMDispatcher
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var cartridges = new List<int> { 10, 50, 100 };
            var amounts = new[]
            {
                30, 50, 60, 80, 140, 230, 370, 610, 980
            };
            foreach (var amount in amounts)
            {
                System.Console.WriteLine($"For the amount {amount} these are the combinations: ");
                Change(amount, cartridges, new List<int>());
                System.Console.WriteLine($"****************************************************");
            }

        }

        private static void Change(int amount, IReadOnlyList<int> cartridges, List<int> combination)
        {
            if (amount < 0 || cartridges.Count == 0) return;
            if (amount == 0)
            {
                PrintNumbers(combination);
                System.Console.Write("\b ;");
                System.Console.WriteLine();
                return;
            }

            var copy = new List<int>(cartridges);
            copy.RemoveAt(0);
            Change(amount, copy, combination);

            combination = new List<int>(combination) { cartridges[0] };
            Change(amount - cartridges[0], cartridges, new List<int>(combination));
        }
        private static void PrintNumbers(IEnumerable<int> list)
        {
            var g = list.GroupBy(i => i);

            foreach (var grp in g)
            {
                System.Console.Write("{0} x {1} +", grp.Count(), grp.Key);
            }
        }
    }
}