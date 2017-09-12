using System;
using System.Threading.Tasks;

namespace Lab1_MPP
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Количество потоков - ");

            var taskQueue = new TaskQueue(Console.Read());
        }
    }
}
