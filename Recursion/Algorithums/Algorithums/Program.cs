using System;
using Algorithums.CircularList;
using Algorithums.LinkedList;
using Algorithums.Recursion;

namespace Algorithums
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //TowerOfHanoi.TowerOfHanoiExecute(5,'A','B','C');
            int[] dataInCircularList = new[] {1, 2, 3, 4, 5, 6,7,8,9,10};

            LinkedList<int> list = new LinkedList<int>();
            foreach (var data in dataInCircularList)
            {
                Console.WriteLine("Inserting Node : "+data);
                list.InsertNode(data);
                list.Print();
            }
            Console.WriteLine("3rd Node from last = "+list.FindNodeFromEndInSingleTraverse(5).Data+". List lenth = "+list.Length());
        }
    }
}