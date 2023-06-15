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

        void CreateFile(string file)
        {
            int i = 0;
            string copyfile = file;
            bool result = false;
            //StreamWriter sr = new StreamWriter("savedfiles.txt");
            //FileStream fileStream = new FileStream("savedfiles.txt", FileMode.Open);
            while (result == false)
            {
                try
                {
                    File.Copy(file+".XLS", selectedPath + @"\"+ copyfile + ".XLS");
                    var proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = selectedPath + @"\"+ copyfile + ".XLS";
                    proc.StartInfo.UseShellExecute = true;
                    proc.Start();
                    //fileStream.Wri(selectedPath + @"\" + copyfile + ".XLS");
                    //sr.WriteLine(selectedPath + @"\" + copyfile + ".XLS");
                    //sr.Close();
                    File.AppendAllText("savedfiles.txt", selectedPath + @"\" + copyfile + ".XLS\n");
                    result = true;
                }
                catch (Exception ex)
                {
                    i = i + 1;
                    copyfile = file + $"({i})";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateFile("balans");
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
            CreateFile("forma2");
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
            CreateFile("forma3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CreateFile("forma4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CreateFile("forma6");
        }
    }
}
