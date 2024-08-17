using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route256
{
    public static class ElectronicTable
    {
        private static readonly Random R = new Random();

        public static void Run(int m, int n)
        {
            int[][] massive = CreateMassive(m, n);

            Print(massive);

            var massive2 = Sort(massive, 1);

            Print(massive2);
        }

        private static int[][] Sort(int[][] massive, int colNum)
        {


            return massive;
        }

        private static int[][] CreateMassive(int m, int n)
        {
            int[][] massive = new int[m][];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    massive[i][j] = R.Next(0, 9);
                }
            }

            return massive;
        }

        private static void Print(int[][] massive)
        {
            for (int i = 0; i < massive.Length; i++)
            {
                for (int j = 0; j < massive[i].Length; j++)
                {
                    Console.Write(massive[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
