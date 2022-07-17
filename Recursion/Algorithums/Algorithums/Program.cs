using Algorithums.CircularList;
using Algorithums.Recursion;

namespace Algorithums
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //TowerOfHanoi.TowerOfHanoiExecute(5,'A','B','C');
            int[] dataInCircularList = new[] {1, 2, 3, 4, 5, 6};

            GenericCircularList<int> circularList = new GenericCircularList<int>();
            foreach (var data in dataInCircularList)
            {
                circularList.InsertNode(data);
                circularList.Print();
            }
        }
    }
}