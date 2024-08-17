using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route256
{
    public static class GoodQueue
    {
        private static string[] _correctOrder => ["AB", "AC", "BC"];

        public static bool Run(string queue)
        {
            var array = queue.ToCharArray();
            
            int aCount = array.Count(x => x == 'A');
            int bCount = array.Count(x => x == 'B');
            int cCount = array.Count(x => x == 'C');

            var start = array.Where(x => x == 'A').ToList();
            var end   = array.Where(x => x == 'C').ToList();

            // system, where x and y are unknown
            // aCount + x = cCount + y  >  y = (aCount + bCount - cCount) / 2
            // x + y = bCount           >  x = bCount - y

            return (aCount + bCount - cCount) % 2 == 0;
        }
    }
}
