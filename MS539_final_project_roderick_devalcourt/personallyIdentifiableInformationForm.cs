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
    public partial class personallyIdentifiableInformationForm : Form
    {
        public personallyIdentifiableInformationForm()
        {
            InitializeComponent();
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetErrors()
        {

            this.errorProvider1.SetError(firstNameTextbox, "");
            this.errorProvider1.SetError(lastNameTextbox, "");
            this.errorProvider1.SetError(genderGroupBox, "");
            this.errorProvider1.SetError(datePicker1, "");
        }

        private bool checkInputs()
        {
            bool result = false;
            int count = 0;


            if (string.IsNullOrEmpty(firstNameTextbox.Text) == true)
            {
                count++;
                this.errorProvider1.SetError(firstNameTextbox, "First Name is a required input!");
            }
            if (string.IsNullOrEmpty(lastNameTextbox.Text) == true)
            {
                count++;
                this.errorProvider1.SetError(lastNameTextbox, "Last Name is a required input!");
            }
            if ((maleRadioButton.Checked == false) && (femaleRadioButton.Checked == false))
            {
                count++;
                this.errorProvider1.SetError(genderGroupBox, "Gender is a required input!");
            }
            if (string.IsNullOrEmpty(datePicker1.Text) == true)
            {
                count++;
                this.errorProvider1.SetError(datePicker1, "Date Of Birth is a required input!");
            }

            if (count == 0)
            {
                result = true;
            }

            return result;
        }

    }
}
