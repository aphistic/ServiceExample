using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace ServiceExample
{
    public partial class ServiceExampleRunner : ServiceBase
    {
        private readonly ServiceExample _service = new ServiceExample();

        public ServiceExampleRunner()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _service.Start(args);
        }

        protected override void OnStop()
        {
            _service.Stop();
        }
    }
}
