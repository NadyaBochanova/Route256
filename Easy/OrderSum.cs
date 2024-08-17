using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route256.Easy
{
    static class OrderSum
    {
        private static readonly KeyValuePair<int, int> _discount;

        static OrderSum()
        {
            _discount = new KeyValuePair<int, int>(3, 2);
        }

        public static int Calculate(int[] products)
        {
            int result = 0;

            foreach (var group in products.GroupBy(price => price))
            {
                int price = group.Key;
                int count = group.Count();

                int x = count / _discount.Key;
                int y = count % _discount.Key;

                result += price * (y + _discount.Value * x);
            }

            return result;
        }
    }
}
