using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MS539_final_project_roderick_devalcourt
{
    public partial class pulseAndOxygenChartForm : Form
    {
        public pulseAndOxygenChartForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            pulseAndOxygenForm dlg = new pulseAndOxygenForm();
            dlg.ShowDialog(this);
        }
    }
}
