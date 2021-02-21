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
    public partial class bloodGlucoseForm : Form
    {
        public bloodGlucoseForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            bloodGlucose = null;
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

            this.errorProvider1.SetError(mgdlTextbox, "");
            this.errorProvider1.SetError(datePicker1, "");
            this.errorProvider1.SetError(timePicker1, "");
        }

        public BloodGlucose bloodGlucose { set; get; }

        private bool checkInputs()
        {
            bool result = false;
            int count = 0;
            decimal mgdl = 0M;
            
            bloodGlucose = new BloodGlucose();

            if (string.IsNullOrEmpty(mgdlTextbox.Text) == true)
            {
                count++;
                this.errorProvider1.SetError(mgdlTextbox, "mg/dl is a required input!");
            }
            else
            {
                if (decimal.TryParse(mgdlTextbox.Text, out mgdl) == false)
                {
                    count++;
                    this.errorProvider1.SetError(mgdlTextbox, "mg/dl is a decimal % (0-200)!");
                }
                else
                {
                    if ((mgdl < 0) || (mgdl > 200))
                    {
                        count++;
                        this.errorProvider1.SetError(mgdlTextbox, "mg/dl is a decimal % (0-200)!");
                    }
                    else
                    {
                        bloodGlucose.MGDL = mgdl;
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
                bloodGlucose.DateRead = datePicker1.Value;
            }

            if (string.IsNullOrEmpty(timePicker1.Text) == true)
            {
                count++;
                this.errorProvider1.SetError(timePicker1, "Time is a required input!");
            }
            else
            {
                bloodGlucose.TimeRead = timePicker1.Value;
            }

            if (count == 0)
            {
                result = true;
            }
            else
            {
                bloodGlucose = null;
            }

            return result;
        }

    }
}
