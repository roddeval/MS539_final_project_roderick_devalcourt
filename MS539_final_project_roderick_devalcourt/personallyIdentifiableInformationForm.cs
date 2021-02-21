using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MS539_final_project_roderick_devalcourt.Entity;
using MS539_final_project_roderick_devalcourt.Logic;

namespace MS539_final_project_roderick_devalcourt
{
    public partial class personallyIdentifiableInformationForm : Form
    {
        ReadFileLogic readFileLogic { set; get; }
        public personallyIdentifiableInformationForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string path = MS539_final_project_roderick_devalcourt.Properties.Settings.Default.DefaultPath;
            string fileName = MS539_final_project_roderick_devalcourt.Properties.Settings.Default.FileName;
            bool result = false;
            WriteFileLogic writeFileLogic = null;
            string pathFileName = "";

            ResetErrors();
            result = checkInputs();
            if (result == true)
            {

                //MessageBox.Show("Form would be saved at this point...");
                writeFileLogic = new WriteFileLogic();

                writeFileLogic.personallyIdentifiableInformation = new PersonallyIdentifiableInformation(personallyIdentifiableInformation);

                foreach (BloodGlucose bloodGlucose1 in readFileLogic.listBloodGlucose)
                {
                    writeFileLogic.listBloodGlucose.Add(new BloodGlucose(bloodGlucose1));
                }
                foreach (PulseAndOxygen pulseAndOxygen1 in readFileLogic.listPulseAndOxygen)
                {
                    writeFileLogic.listPulseAndOxygen.Add(new PulseAndOxygen(pulseAndOxygen1));
                }
                writeFileLogic.PathName = path;
                writeFileLogic.FileName = fileName;
                pathFileName = writeFileLogic.GetFormattedFileName();
                writeFileLogic.WriteFile();

                this.Close();
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

        public PersonallyIdentifiableInformation personallyIdentifiableInformation { set; get; }

        private bool checkInputs()
        {
            bool result = false;
            int count = 0;

            personallyIdentifiableInformation = new PersonallyIdentifiableInformation();

            if (string.IsNullOrEmpty(firstNameTextbox.Text) == true)
            {
                count++;
                this.errorProvider1.SetError(firstNameTextbox, "First Name is a required input!");
            }
            else
            {
                personallyIdentifiableInformation.FirstName = firstNameTextbox.Text;
            }
            if (string.IsNullOrEmpty(lastNameTextbox.Text) == true)
            {
                count++;
                this.errorProvider1.SetError(lastNameTextbox, "Last Name is a required input!");
            }
            else
            {
                personallyIdentifiableInformation.LastName = lastNameTextbox.Text;
            }
            if ((maleRadioButton.Checked == false) && (femaleRadioButton.Checked == false))
            {
                count++;
                this.errorProvider1.SetError(genderGroupBox, "Gender is a required input!");
            }
            else
            {
                if (maleRadioButton.Checked == true)
                {
                    personallyIdentifiableInformation.Gender = 0;
                }
                if (femaleRadioButton.Checked == true)
                {
                    personallyIdentifiableInformation.Gender = 1;
                }
            }
            if (string.IsNullOrEmpty(datePicker1.Text) == true)
            {
                count++;
                this.errorProvider1.SetError(datePicker1, "Date Of Birth is a required input!");
            }
            else
            {
                personallyIdentifiableInformation.DateOfBirth = datePicker1.Value;
            }

            if (count == 0)
            {
                result = true;
            }
            else
            {
                personallyIdentifiableInformation = null;
            }

            return result;
        }

        private void personallyIdentifiableInformationForm_Load(object sender, EventArgs e)
        {
            LoadPII();
        }

        private void LoadPII()
        {
            StringBuilder stringBuilder = null;
            string messageText = "";
            Exception exceptionDetails = null;
            string path = MS539_final_project_roderick_devalcourt.Properties.Settings.Default.DefaultPath;
            string fileName = MS539_final_project_roderick_devalcourt.Properties.Settings.Default.FileName;

            try
            {

                readFileLogic = new ReadFileLogic();
                if (readFileLogic != null)
                {
                    readFileLogic.PathName = path;
                    readFileLogic.FileName = fileName;
                    readFileLogic.GetFormattedFileName();

                    if (File.Exists(readFileLogic.FilePathName) == true)
                    {
                        readFileLogic.ReadFile();
                        readFileLogic.SetupListsByDay();

                        firstNameTextbox.Text = readFileLogic.personallyIdentifiableInformation.FirstName;
                        lastNameTextbox.Text = readFileLogic.personallyIdentifiableInformation.LastName;
                        switch (readFileLogic.personallyIdentifiableInformation.Gender)
                        {

                            case 0:
                                maleRadioButton.Checked = true;
                                femaleRadioButton.Checked = false;
                                break;

                            case 1:
                                maleRadioButton.Checked = false;
                                femaleRadioButton.Checked = true;
                                break;

                        }
                        datePicker1.Value = readFileLogic.personallyIdentifiableInformation.DateOfBirth;
                        personallyIdentifiableInformation = new PersonallyIdentifiableInformation(readFileLogic.personallyIdentifiableInformation);
                    }
                }

            }
            catch (ArgumentOutOfRangeException oops)
            {
                // do nothing
            }
            catch (Exception exception)
            {
                stringBuilder = new StringBuilder();
                exceptionDetails = exception;

                while (exceptionDetails != null)
                {

                    messageText = "\r\nMessage: " + exceptionDetails.Message + "\r\nSource: " + exceptionDetails.Source + "\r\nStack Trace: " + exceptionDetails.StackTrace + "\r\n----------\r\n";

                    stringBuilder.Append(messageText);

                    exceptionDetails = exceptionDetails.InnerException;

                }

                messageText = stringBuilder.ToString();

                System.Diagnostics.Debug.WriteLine(messageText);
                MessageBox.Show(this, messageText, "Error");

            }
        }
    }
}
