/*
 Name                   Date            Program Description
 Roderick DeValcourt    01/31/2021      Health Information Tracker

Estimate: 40 hours of work

Date            hours of work       Description
1/31/2021       1                   setup solution
1/31/2021       0.50                mainWindowForm.cs
1/31/2021       0.50                personallyIdentifiableInformationForm.cs
1/31/2021       0.50                bloodGlucoseChartForm.cs
1/31/2021       0.50                bloodGlucoseForm.cs
1/31/2021       0.50                pulseAndOxygenChartForm.cs
1/31/2021       0.50                pulseAndOxygenForm.cs
1/31/2021       0.25                aboutForm.cs

2/7/2021        0.50                Identifier.cs
2/7/2021        0.50                PersonallyIdentifiableInformation.cs
2/7/2021        0.50                PulseAndOxygen.cs
2/7/2021        0.50                BloodGlucose.cs
2/7/2021        1.5                 ConvertLogic.cs
2/7/2021        1.5                 ReadFileLogic.cs
2/7/2021        1.5                 frmTestReadFileLogic.cs
2/7/2021        0.25                HealthInformationTracker.txt

2/14/2021       1.0                 ConvertLogic.cs
2/14/2021       1.0                 LogicBase.cs
2/14/2021       1.0                 ReadFileLogic.cs    (refactored to use LogicBase base class)
2/14/2021       1.0                 WriteFileLogic.cs
2/14/2021       0.25                PersonallyIdentifiableInformation.cs (refactored, added Copy Constructor)
                                    BloodGlucose.cs (refactored, added Copy Constructor)
                                    Director.cs
                                    Builder.cs
                                    PlainTextBuilder.cs
                                    EncryptedTextBuilder.cs

2/19/2021       2.50                bloodGlucoseChartForm (got a basic line chart with testdata to show)
2/21/2021       0.5                 pulseAndOxygenChartForm.cs
2/21/2021       0.5                 readFileLogic.cs added method SetupListsByDay
2/21/2021       0.5                 pulseAndOxygenChartForm.cs (got a basic line chart with testdata to show)
2/21/2021       0.25                pulseAndOxygenChartForm.cs (added group box for today, this week, this month)
2/21/2021       0.25                bloodGlucoseChartForm.cs (added group box for today, this week, this month)
2/21/2021       0.5                 pulseAndOxygenChartForm.cs  wrote save logic, fixed LoadChart to use radiobutton selection
2/21/2021       0.5                 bloodGlucoseChartForm.cs wrote save logic, fixed LoadChart to use radiobutton selection

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

        private void testReadFileLogicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestReadFileLogic dlg = new frmTestReadFileLogic();
            dlg.ShowDialog(this);
        }
    }
}
