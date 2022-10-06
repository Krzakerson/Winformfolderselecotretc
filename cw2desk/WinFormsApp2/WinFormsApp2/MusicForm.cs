using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp2
{
    public partial class MusicForm : Form
    {
        int x = 747, y = 1;
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        public MusicForm()
        {
            InitializeComponent();
            listBox1.Visible = false;
        }
        string[] paths, files;
        private void btnSelect_Click(object sender, EventArgs e)
        {
            
        }



        private void btnPlay_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.SetBounds(x,y,1,1);
            x--;
            if(x<-300)
            {
                x = 747;
            }
        }

        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {


                string name = ofd.FileName;

                player.URL = ofd.FileName;

                player.controls.play();

                label1.Text = "Currently playing " + name;
                label1.Font = new Font("", 22, FontStyle.Bold);
                timer1.Interval = 1;
                timer1.Start();


            }
            else
            {
                MessageBox.Show("Podczas wybierania doszlo do bledu");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
            player.controls.pause();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           
        }

        private void guna2TrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        private void guna2TrackBar1_Scroll_1(object sender, ScrollEventArgs e)
        {
            player.settings.volume = gunatrack.Value;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            player.controls.play();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            player.settings.volume = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd2 = new OpenFileDialog();
            ofd2.Multiselect = true;
            if(ofd2.ShowDialog() == DialogResult.OK)
            {
                files = ofd2.SafeFileNames;
                paths = ofd2.FileNames;
                listBox1.Visible = true;
                for (int i = 0; i < files.Length; i++)
                {
                    listBox1.Items.Add(files[i]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            player.controls.play();
        }
    }
}
