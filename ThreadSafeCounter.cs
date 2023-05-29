using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TasksApp
{
    public class ThreadSafeCounter
    {
        private int count = 0;
        private object countLock = new object();

        public int Count => count;

        public void Increment()
        {
            lock (countLock)
            {
                count++;
            }
        }
    }
}
