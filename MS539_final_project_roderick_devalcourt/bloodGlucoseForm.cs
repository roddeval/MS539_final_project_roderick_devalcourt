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
    public partial class bloodGlucoseForm : Form
    {
        public bloodGlucoseForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            bool result = false;
            ResetErrors();
            result = checkInputs();
            if (result == true)
            {
                MessageBox.Show("Form would be saved at this point...");
            }
        }

        private void ResetErrors()
        {

            this.errorProvider1.SetError(mgdlTextbox, "");
            this.errorProvider1.SetError(datePicker1, "");
            this.errorProvider1.SetError(timePicker1, "");
        }

        private bool checkInputs()
        {
            bool result = false;
            int count = 0;
            decimal mgdl = 0M;

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
                }
            }
            if (string.IsNullOrEmpty(datePicker1.Text) == true)
            {
                count++;
                this.errorProvider1.SetError(datePicker1, "Date is a required input!");
            }
            if (string.IsNullOrEmpty(timePicker1.Text) == true)
            {
                count++;
                this.errorProvider1.SetError(timePicker1, "Time is a required input!");
            }

            if (count == 0)
            {
                result = true;
            }

            return result;
        }

    }
}
