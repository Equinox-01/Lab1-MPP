using System;
using System.Threading;

namespace Lab1_MPP
{
    public static class RandInterruption
    {
        const
            int MIN_TIME = 1,
                MAX_TIME = 5;

        public static void GetRandomInterrupt()
        {
            Random rand = new Random(Thread.CurrentThread.ManagedThreadId);
            int sleep_time = rand.Next(MIN_TIME, MAX_TIME);
            Console.WriteLine("Прерывание на " + sleep_time + " секунд(у)");
            Thread.Sleep(sleep_time * 1000);
        }
    }
}
