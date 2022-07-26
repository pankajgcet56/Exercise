using System;
using System.Threading;

namespace O9Test
{
    internal class Program
    {
        private static int size = 10;
        private static Inventory inventory ;
        public static void Main(string[] args)
        {
            inventory = new Inventory(size);
            while (true)
            {
                Thread.Sleep(1000);
                PerformOnOperation();
            }
        }

        static void PerformOnOperation()
        {
            Random random = new Random();
            int nextRand = random.Next(0, 30000);
            Console.WriteLine("Found random : "+nextRand%3);
            int randomIndex = (random.Next(0, 70000))%(size);
            
            int randomDelta = random.Next(0, 20);
            switch (nextRand%3)
            {
                case 0:
                    // Read Node at Random Index
                    Console.WriteLine("==============================READ================================");
                    Console.WriteLine(" Inventory =  "+inventory.GetInventory(randomIndex));
                    Console.WriteLine("==============================================================");
                    break;
                case 1:
                    Console.WriteLine("==============================Add Demand================================");
                    inventory.AddDemand(randomIndex,randomDelta).Print();
                    Console.WriteLine("==============================================================");
                    break;
                case 2:
                    Console.WriteLine("==============================ADD SUPPLY================================");
                    inventory.AddSupply(randomIndex,randomDelta).Print();
                    Console.WriteLine("==============================================================");
                    break;
            }
        }
    }
}