using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab1_MPP.ThreadPool
{
    public class TaskQueue
    {
        private Queue<TaskDelegate> tasks_queue = new Queue<TaskDelegate>();
        private List<ThreadUsable> threads = new List<ThreadUsable>();

        public TaskQueue(int capacity)
        {
            if (capacity <= 0)
                throw new InvalidOperationException("Недопустимый параметр конструктора.");
            else
                for (int i = 0; i < capacity; i++)
                {
                    threads.Add(new ThreadUsable());
                    threads[i].inUse = false;
                }
        }

        public void EnqueueTask(TaskDelegate task)
        {
            tasks_queue.Enqueue(task);
            var progress = tasks_queue.Dequeue();
            while (true)
            {
                for (int i = 0; i < threads.Count; i++)
                {
                    if (!threads[i].inUse)
                    {
                        threads[i].thread = new Thread(new ThreadStart(progress));
                        threads[i].thread.IsBackground = false;
                        threads[i].inUse = true;
                        threads[i].thread.Start();
                        return;
                    }
                    else
                        threads[i].inUse = threads[i].thread.IsAlive;
                }
            }
        }
    }
}
