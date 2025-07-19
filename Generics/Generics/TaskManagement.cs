using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class TaskManagement
    {
        public interface ITask<TResult>
        {
            public TResult Perform();
        }

        internal class EmailTask : ITask<string>
        {
            public string Recipient { get; set; }
            public string Message { get; set; }
            public string Perform()
            {
                return $"{Message} sent to {Recipient}.";
            }
        }

        internal class ReportTask: ITask<string>
        {
            public string ReportName { get; set; }

            public string Perform()
            {
                return $"Generating report - successfully generated {ReportName}.";
            }
        }

        internal class TaskProcessor<TTask, TResult> where TTask : ITask<TResult>
        {
            private readonly TTask _task;

            public TaskProcessor(TTask task)
            {
                _task = task;
            }

            public TResult Execute()
            {
                return _task.Perform();
            }
        }
    }
}
