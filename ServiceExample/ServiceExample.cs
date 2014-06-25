using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceExample.DomainExample;

namespace ServiceExample
{
    public class ServiceExample
    {
        private bool _isRunning;

        private EmailWorker _emailWorker = null;

        public void Start(string[] args)
        {
            if (_isRunning)
            {
                return;
            }

            _emailWorker = new EmailWorker();
            var emailState = new EmailWorker.WorkerState
                                 {
                                     Args = args,
                                     SomeOtherInfo = 12345
                                 };
            _emailWorker.Start(emailState);

            _isRunning = true;
        }

        public void Stop()
        {
            if (!_isRunning)
            {
                return;
            }

            _emailWorker.Stop();
            _emailWorker = null;

            _isRunning = false;
        }
    }
}
