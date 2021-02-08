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
    public partial class frmTestReadFileLogic : Form
    {
        public frmTestReadFileLogic()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sPath = "";
            string sSelectedPath = "";
            sPath = tbPath.Text;
            if (sPath.Length == 0)
            {
                sPath = MS539_final_project_roderick_devalcourt.Properties.Settings.Default.DefaultPath;
            }
            if (sPath.EndsWith("\\") == false)
            {
                sPath += "\\";
            }

            folderBrowserDialog1.SelectedPath = sPath;
            DialogResult result = folderBrowserDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                sSelectedPath = folderBrowserDialog1.SelectedPath;
                if (sSelectedPath.EndsWith("\\") == false)
                {
                    sSelectedPath += "\\";
                }
                tbPath.Text = sSelectedPath;
                this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();

            }

        }
        private void ResetListBox()
        {
            listBox1.Items.Clear();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = null;
            string messageText = "";
            Exception exceptionDetails = null;
            string path = tbPath.Text;
            string fileName = tbFileName.Text;
            ReadFileLogic readFileLogic = null;
            try
            {
                ResetListBox();
                if ((string.IsNullOrEmpty(path) == false) && (string.IsNullOrEmpty(fileName) == false))
                {
                    readFileLogic = new ReadFileLogic();
                    if (readFileLogic != null)
                    {
                        readFileLogic.PathName = path;
                        readFileLogic.FileName = fileName;
                        readFileLogic.ReadFile();
                        messageText = ConvertLogic.ConvertPersonallyIdentifiableInformationToString(readFileLogic.personallyIdentifiableInformation);
                        listBox1.Items.Add(messageText);
                        foreach (BloodGlucose bloodGlucose in readFileLogic.listBloodGlucose)
                        {
                            messageText = ConvertLogic.ConvertBloodGlucoseToString(bloodGlucose);
                            listBox1.Items.Add(messageText);
                        }

                        foreach (PulseAndOxygen pulseAndOxygen in readFileLogic.listPulseAndOxygen)
                        {
                            messageText = ConvertLogic.ConvertPulseAndOxygenToString(pulseAndOxygen);
                            listBox1.Items.Add(messageText);
                        }
                    }
                }
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

                listBox1.Items.Add(messageText);

            }

        }

        private void frmTestReadFileLogic_Load(object sender, EventArgs e)
        {
            this.tbFileName.Text = MS539_final_project_roderick_devalcourt.Properties.Settings.Default.FileName;
            this.tbPath.Text = MS539_final_project_roderick_devalcourt.Properties.Settings.Default.DefaultPath;
        }
    }
}
