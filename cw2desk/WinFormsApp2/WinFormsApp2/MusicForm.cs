using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class MusicForm : Form
    {
        int x = 747, y = 1;
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        public MusicForm()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
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



        private void btnPlay_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            player.controls.stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.SetBounds(x,y,1,1);
            x--;
            if(x<-100)
            {
                x = 747;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            player.controls.play();
        }
    }
}
