/*
 Name                   Date            Program Description
 Roderick DeValcourt    01/31/2021      Health Information Tracker

Estimate: 40 hours of work

Date            hours of work       Description
1/31/2021                           setup solution
1/31/2021                           mainWindowForm.cs
1/31/2021                           personallyIdentifiableInformationForm.cs
1/31/2021                           bloodGlucoseChartForm.cs
1/31/2021                           bloodGlucoseForm.cs
1/31/2021                           pulseAndOxygenChartForm.cs
1/31/2021                           pulseAndOxygenForm.cs
1/31/2021                           aboutForm.cs

 */
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
    public partial class mainWindowForm : Form
    {
        public mainWindowForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutForm dlg = new aboutForm();
            dlg.ShowDialog(this);
        }

        private void personallyIdentifiableInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personallyIdentifiableInformationForm dlg = new personallyIdentifiableInformationForm();
            dlg.ShowDialog(this);
        }

        private void bloodGlucoseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bloodGlucoseChartForm dlg = new bloodGlucoseChartForm();
            dlg.ShowDialog(this);

        }

        private void pulseOxygenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pulseAndOxygenChartForm dlg = new pulseAndOxygenChartForm();
            dlg.ShowDialog(this);

        }
    }
}
