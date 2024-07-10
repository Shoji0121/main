using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace e
{
    public partial class Form1 : Form
    {
        private string bashrcPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "/home/torizon/.bashrc");
        private const string settingName = "MY_SETTING";
        string readText;
        string path = "/var/rootdirs/home/torizon/Language.txt";
        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            // Load the image
            this.pictureBox1.ImageLocation = "./assets/torizon-logo.png";
        }

        private void UpdateMySetting_text(string languageCode)
        {
            string content = "Language:" + languageCode;
            content= string.Format("Language:{0}", languageCode);


            if (!File.Exists(path))
            {
                using (File.Create(path)) {}
            }

            File.WriteAllText(path, content);
            
            var process = new System.Diagnostics.Process
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "bash",
                    Arguments = $"-c \"cat {path}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            process.WaitForExit();
            readText = process.StandardOutput.ReadToEnd();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(path))
                {
                    var process = new System.Diagnostics.Process
                    {
                        StartInfo = new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = "bash",
                            Arguments = $"-c \"cat {path}\"",
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true,
                        }
                    };
                    process.Start();
                    process.WaitForExit();
                    readText = process.StandardOutput.ReadToEnd();
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return;
            }
            Console.WriteLine("あああああ");
            label1.Text = "あいうえおカキクケコ差市巣背祖ㄹ퍋高等级";

            if(readText == "Language:1400")
            {
                label1.Text = "日本語";
                UpdateMySetting_text("1200");
            }
            else if(readText == "Language:1200")
            {
                label1.Text = "English";
                UpdateMySetting_text("1400");
            }
            else
            {
                label1.Text = "Error";
                UpdateMySetting_text("1200");
            }
        }
        
    }
}
