using System;

namespace Lab1_MPP
{
    public delegate void TaskDelegate();

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Количество потоков - ");
            try
            {
                var tQueue = new TaskQueue(int.Parse(Console.ReadLine()));
                tQueue.EnqueueTask(RandInterruption.GetRandomInterrupt);
                tQueue.EnqueueTask(RandInterruption.GetRandomInterrupt);
                tQueue.EnqueueTask(RandInterruption.GetRandomInterrupt);
                tQueue.EnqueueTask(RandInterruption.GetRandomInterrupt);
                tQueue.EnqueueTask(RandInterruption.GetRandomInterrupt);
                tQueue.EnqueueTask(RandInterruption.GetRandomInterrupt);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}
