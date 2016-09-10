using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser_auto_reload
{
    public partial class Main : Form
    {
        bool watching;
        public Main()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack)
                button_back.Enabled = true;
            else
                button_back.Enabled = false;
            if (webBrowser1.CanGoForward)
                button_up.Enabled = true;
            else
                button_up.Enabled = false;
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button_up_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            textBox1.Text = webBrowser1.Url.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath;
                button3.Enabled = true;
                textBox2.Text = path;
                fileSystemWatcher1.Path = path;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (watching)
            {
                watching = false;
                //button3.FlatStyle = FlatStyle.Flat;
                button3.ForeColor = Color.Black;
                button3.Text = "WATCH and RELOAD";
            }else
            {
                //button3.FlatStyle = FlatStyle.Standard;
                button3.ForeColor = Color.DarkGreen;
                button3.Text = "WATCHING";
                watching = true;
            }
            
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DO NOT USE FOR DESIGNING FRONT-END WEB APPLICATIONS, THE BROWSER IS BASED ON AN OLD VERSION OF IE BROWSER!"+ Environment.NewLine + Environment.NewLine + "1. Navigate to the page you want to refresh" +Environment.NewLine+"2. Select the folder to watch for changes"+Environment.NewLine+"3. Click the watch button" +Environment.NewLine+"4. Build something amazing (most important step)"+Environment.NewLine+Environment.NewLine+"© Alexandru Cambose", "Some info",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            Main.ActiveForm.Text = "Navigating...";
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            Main.ActiveForm.Text = "Live reload";
           
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                webBrowser1.Navigate(textBox1.Text);
            }
        }
    }
}
