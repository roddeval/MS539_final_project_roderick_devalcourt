using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MS539_final_project_roderick_devalcourt.Entity;
using MS539_final_project_roderick_devalcourt.Logic;

namespace MS539_final_project_roderick_devalcourt
{
    public partial class pulseAndOxygenForm : Form
    {
        public pulseAndOxygenForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            pulseAndOxygen = null;
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            bool result = false;
            ResetErrors();
            result = checkInputs();
            if (result == true)
            {
                //MessageBox.Show("Form would be saved at this point...");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }


        private void ResetErrors()
        {

            this.errorProvider1.SetError(pulseTextbox, "");
            this.errorProvider1.SetError(oxygenTextbox, "");
            this.errorProvider1.SetError(datePicker1, "");
            this.errorProvider1.SetError(timePicker1, "");
        }

        public PulseAndOxygen pulseAndOxygen { set; get; }

        private bool checkInputs()
        {
            bool result = false;
            int pulse = 0;
            decimal oxygen = 0M;
            int count = 0;

            pulseAndOxygen = new PulseAndOxygen();

            if (string.IsNullOrEmpty(pulseTextbox.Text) == true)
            {
                count++;
                this.errorProvider1.SetError(pulseTextbox, "Pulse is a required input!");

            }
            else
            {
                if (Int32.TryParse(pulseTextbox.Text, out pulse) == false)
                {
                    count++;
                    this.errorProvider1.SetError(pulseTextbox, "Pulse is a integer (0-200)!");

                }
                else
                {
                    if ((pulse < 0) || (pulse > 200))
                    {
                        count++;
                        this.errorProvider1.SetError(pulseTextbox, "Pulse is a integer (0-200)!");
                    }
                    else
                    {
                        pulseAndOxygen.Pulse = pulse;
                    }
                }
            }
            if (string.IsNullOrEmpty(oxygenTextbox.Text) == true)
            {
                count++;
                this.errorProvider1.SetError(oxygenTextbox, "Oxygen is a required input!");
            }
            else
            {
                if (decimal.TryParse(oxygenTextbox.Text, out oxygen) == false)
                {
                    count++;
                    this.errorProvider1.SetError(oxygenTextbox, "Oxygen is a decimal % (0-100)!");
                }
                else
                {
                    if ((oxygen < 0) || (oxygen > 200))
                    {
                        count++;
                        this.errorProvider1.SetError(oxygenTextbox, "Oxygen is a decimal % (0-100)!");
                    }
                    else
                    {
                        pulseAndOxygen.Oxygen = oxygen;
                    }
                }
            }
            if (string.IsNullOrEmpty(datePicker1.Text) == true)
            {
                count++;
                this.errorProvider1.SetError(datePicker1, "Date is a required input!");
            }
            else
            {
                pulseAndOxygen.DateRead = datePicker1.Value;
            }

            if (string.IsNullOrEmpty(timePicker1.Text) == true)
            {
                count++;
                this.errorProvider1.SetError(timePicker1, "Time is a required input!");

            }
            else
            {
                pulseAndOxygen.TimeRead = timePicker1.Value;
            }

            if (count == 0)
            {
                result = true;

            }
            else
            {
                pulseAndOxygen = null;
            }

            return result;
        }

    }
}
