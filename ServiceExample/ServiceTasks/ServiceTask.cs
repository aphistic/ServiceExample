using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ServiceExample.ServiceTasks
{
    internal abstract class ServiceTask
    {
        private readonly ManualResetEvent _serviceShouldStop = new ManualResetEvent(false);
        private readonly ManualResetEvent _serviceFinished = new ManualResetEvent(false);

        private bool _isRunning = false;
        private Thread _taskThread = null;

        public void Start()
        {
            Start(null);
        }
        public void Start(object taskState)
        {
            if (_isRunning)
            {
                return;
            }

            _serviceShouldStop.Reset();
            _serviceFinished.Reset();

            _taskThread = new Thread(Run);
            _taskThread.Start(taskState);

            _isRunning = true;
        }

        public void Stop()
        {
            Stop(null);
        }
        public void Stop(int? millisecondsToWait)
        {
            if (!_isRunning)
            {
                return;
            }

            millisecondsToWait = millisecondsToWait ?? Timeout.Infinite;

            _serviceShouldStop.Set();

            _serviceFinished.WaitOne(millisecondsToWait.Value);

            _isRunning = false;
        }

        protected bool ShouldStop()
        {
            return ShouldStop(null);
        }
        protected bool ShouldStop(int? millisecondsToWait)
        {
            millisecondsToWait = millisecondsToWait ?? Timeout.Infinite;
            return _serviceShouldStop.WaitOne(millisecondsToWait.Value);
        }

        protected void HasFinished()
        {
            _serviceFinished.Set();
        }

        protected abstract void Run(object state);
    }
}
