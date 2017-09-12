using System.Collections.Generic;
using System.Threading;

namespace Lab1_MPP
{
    public class TaskQueue
    {
        public delegate void TaskDelegate();
        private Queue<TaskDelegate> taskQueue;
        private List<Thread> threadList;

        public TaskQueue(int value)
        {
            for (int i = 0; i < value; i++)
            {
                threadList.Add(new Thread(new ThreadStart(taskQueue.Dequeue())));
            }
        }

        public void EnqueueTask(TaskDelegate task)
        {
            taskQueue.Enqueue(task);
        }
    }
}
