using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FullStopDotNet2014.Common.Utilities
{
    //Copied from  Microsoft.AspNet.Identity which has this class, except it's internal
    public static class AsyncHelper
    {
        private static readonly TaskFactory _myTaskFactory = new TaskFactory(CancellationToken.None,
            TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);

        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
        {
            return _myTaskFactory.StartNew(func).Unwrap().GetAwaiter().GetResult();
        }

        public static void RunSync(Func<Task> func)
        {
            _myTaskFactory.StartNew(func).Unwrap().GetAwaiter().GetResult();
        }
    }
}
