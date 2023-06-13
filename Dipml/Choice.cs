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
using System.Xml.Serialization;

namespace Dipml
{
    public partial class Choice : Form
    {
        public Choice()
        {
            InitializeComponent();
        }

        public class Setting
        {
            public string selectedPath;
        }

        public string selectedPath;

        private void Settings_Load(object sender, EventArgs e)
        {
            Setting settings = new Setting();
            if (File.Exists("Program.xml") == false)
            {
                using (Stream writer = new FileStream("Program.xml", FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Setting));
                    serializer.Serialize(writer, settings);
                }
            }
            using (Stream stream = new FileStream("Program.xml", FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Setting));
                settings = (Setting)serializer.Deserialize(stream);
                selectedPath = settings.selectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.Copy("balans.XLS", selectedPath+ @"\balans.XLS");
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = selectedPath + @"\balans.XLS";
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }

        private void Choice_Load(object sender, EventArgs e)
        {
            Setting settings = new Setting();
            if (File.Exists("Program.xml") == false)
            {
                using (Stream writer = new FileStream("Program.xml", FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Setting));
                    serializer.Serialize(writer, settings);
                }
            }
            using (Stream stream = new FileStream("Program.xml", FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Setting));
                settings = (Setting)serializer.Deserialize(stream);
                selectedPath = settings.selectedPath;
            }
            textBox1.Text = selectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.Copy("forma2.XLS", selectedPath + @"\forma2.XLS");
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = selectedPath + @"\forma2.XLS";
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            selectedPath = folderBrowserDialog1.SelectedPath;
            Setting settings = new Setting();
            using (Stream writer = new FileStream("Program.xml", FileMode.Create))
            {
                settings.selectedPath = selectedPath;
                XmlSerializer serializer = new XmlSerializer(typeof(Setting));
                serializer.Serialize(writer, settings);
            }
            textBox1.Text = selectedPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            File.Copy("forma3.XLS", selectedPath + @"\forma3.XLS");
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = selectedPath + @"\forma3.XLS";
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            File.Copy("forma4.XLS", selectedPath + @"forma4.XLS");
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = selectedPath + @"\forma4.XLS";
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            File.Copy("forma6.XLS", selectedPath + @"\forma6.XLS");
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = selectedPath + @"\forma6.XLS";
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }
    }
}
