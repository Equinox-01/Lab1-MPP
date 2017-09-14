using System;

namespace Lab1_MPP
{
    public delegate void TaskDelegate();

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Количество потоков - ");
            var tQueue = new ThreadPool.TaskQueue(int.Parse(Console.ReadLine()));
            tQueue.EnqueueTask(RandInterruption.GetRandomInterrupt);
            tQueue.EnqueueTask(RandInterruption.GetRandomInterrupt);
            tQueue.EnqueueTask(RandInterruption.GetRandomInterrupt);
            tQueue.EnqueueTask(RandInterruption.GetRandomInterrupt);
            tQueue.EnqueueTask(RandInterruption.GetRandomInterrupt);
            tQueue.EnqueueTask(RandInterruption.GetRandomInterrupt);
        }
    }
}
