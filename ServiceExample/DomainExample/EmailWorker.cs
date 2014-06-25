using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceExample.ServiceTasks;

namespace ServiceExample.DomainExample
{
    internal class EmailWorker : ServiceTask
    {
        protected override void Run(object state)
        {
            // Get the state and do what we want with it.
            var workerState = state as WorkerState;

            // Set up the runtime here

            // Run a loop until something tells us to stop (like a ServiceTask.Stop())
            while (!ShouldStop(1000))
            {
                // Do any tasks you want to do over and over again.

                // Even if you're using a Timer to fire off the events, you'll want to set this
                // up as an infinite loop so the thread doesn't exit (as it will when the method
                // ends).  If you do, you can bump up the wait even higher.  Keep in mind that the
                // thread is blocking while this is waiting, so no processing is happening on this thread.
            }

            // Notify ServiceTask that the task has finished, so it can trigger
            // the event that finishes any Stop() methods that are blocking.
            HasFinished();
        }

        internal class WorkerState
        {
            public string[] Args { get; set; }
            public int SomeOtherInfo { get; set; }
        }
    }
}
