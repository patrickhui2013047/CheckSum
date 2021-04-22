using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class Progress
    {
        public int TaskCount { get; private set; }
        public int TaskComplete { get; private set; }
        public float Percentage { get; private set; }
        
        public Progress(int count)
        {
            TaskCount = count;
            TaskComplete = 0;
            Calculate();
        }

        public void AddTask(int number = 1)
        {
            TaskCount += number;
        }

        public void DoneTask(int number = 1)
        {
            TaskComplete += number;
        }

        private void Calculate()
        {
            Percentage = ((float)TaskComplete / (float)TaskCount);
        }
    }
}
