using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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

namespace JsonProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Configuration cfn = new Configuration();

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                cfn.SetTextSpeed = true;
            else
                cfn.SetTextSpeed = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                cfn.ShowProgressBar = true;
            else
                cfn.ShowProgressBar = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                cfn.StopOnFailed = true;
            else
                cfn.StopOnFailed = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            




            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Title = "Save text Files";

            saveFileDialog1.DefaultExt = "json";

            saveFileDialog1.Filter = "Text files (*.json)|*.json|All files (*.*)|*.*";

            saveFileDialog1.FilterIndex = 2;

            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                cfn.ProjectName = textBox2.Text;

                string output = JsonConvert.SerializeObject(cfn, Formatting.Indented);

                textBox1.Clear();
                textBox1.Text = output;
                JsonSerializer serializer = new JsonSerializer();
                serializer.Converters.Add(new JavaScriptDateTimeConverter());
                serializer.NullValueHandling = NullValueHandling.Ignore;

                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, cfn);
                }


            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string config_file = openFileDialog1.FileName;

                // deserialize JSON directly from a file
                using (StreamReader file = File.OpenText(config_file))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    Configuration cfnFile = (Configuration)serializer.Deserialize(file, typeof(Configuration));

                    cfn.ProjectName = cfnFile.ProjectName;
                    cfn.SetTextSpeed = cfnFile.SetTextSpeed;
                    cfn.StopOnFailed = cfnFile.StopOnFailed;
                    cfn.ShowProgressBar = cfnFile.ShowProgressBar;

                    MessageBox.Show("Loaded");

                    if (cfn.ShowProgressBar.Equals(true))
                    {
                        checkBox2.Checked = true;
                    }
                    else
                    {
                        checkBox2.Checked = false;
                    }

                    if (cfn.StopOnFailed.Equals(true))
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }

                    if(cfn.SetTextSpeed.Equals(true))
                    {
                        checkBox3.Checked = true;
                    } else
                    {
                        checkBox3.Checked = false;
                    }

                }
            }
        }



        private void Form1_Activated(object sender, EventArgs e)
        {
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            
        }

        
    }
}
