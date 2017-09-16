using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab1_MPP
{
    public class TaskQueue
    {
        private volatile Queue<TaskDelegate> tasks_queue = new Queue<TaskDelegate>();
        private List<Thread> threads = new List<Thread>();
        private object thisLock = new object();

        public TaskQueue(int capacity)
        {
            if (capacity <= 0)
                throw new InvalidOperationException("Недопустимый параметр конструктора.");
            else
                for (int i = 0; i < capacity; i++)
                {
                    var thread = new Thread(GetTask);
                    thread.IsBackground = false;
                    threads.Add(thread);
                    thread.Start();
                }
        }

        public void EnqueueTask(TaskDelegate task)
        {
            tasks_queue.Enqueue(task);
            
        }
        private void GetTask()
        {
            while (true)
            {
                if (tasks_queue != null)
                {
                    try
                    {
                        TaskDelegate proc_thread = null;
                        lock(thisLock)
                        {
                            proc_thread = tasks_queue.Dequeue();
                        }
                        proc_thread();

                    }
                    catch (InvalidOperationException)
                    {
                        return;
                    }
                    
                }
            }
        }
    }
}
