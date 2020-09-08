using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PadsShowDemo
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        PadsChart exPC = null;
        private void button1_Click(object sender, EventArgs e)
        {
            if (exPC == null || exPC.IsDisposed)
            {
                exPC = new PadsChart(false);
                exPC.SetUpPadsChart(1, 1, 150, 200);

                exPC.Show();
            }
            else
                exPC.Activate();
        }
    }
}
