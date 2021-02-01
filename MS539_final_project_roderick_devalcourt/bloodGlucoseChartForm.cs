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
    public partial class bloodGlucoseChartForm : Form
    {
        public bloodGlucoseChartForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {

            bloodGlucoseForm dlg = new bloodGlucoseForm();
            dlg.ShowDialog(this);
        }
    }
}
