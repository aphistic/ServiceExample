using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ServiceExample.Tester
{
    public partial class FormMain : Form
    {
        private readonly ServiceExample _service = new ServiceExample();

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnStartService_Click(object sender, EventArgs e)
        {
            _service.Start(null);
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            _service.Stop();
        }

    }
}
