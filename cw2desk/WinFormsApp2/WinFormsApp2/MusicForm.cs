using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Mp3Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2.Models;
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
            dataGridView1.Visible = false;
            
        }
        List<TagsFolder> tags = new List<TagsFolder>();
        List<TagsFolder> tags2 = new List<TagsFolder>();
        string[] artists, albums, titles, years;
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
                
                Mp3Lib.Mp3File mp3File = new Mp3Lib.Mp3File(ofd.FileName);
                string artist = mp3File.TagHandler.Artist; 
                string album = mp3File.TagHandler.Album;
                string title = mp3File.TagHandler.Title;
                string year = mp3File.TagHandler.Year;

               
                tags.Add(new TagsFolder { artist = artist , album = album, title = title, year = year });   
                player.URL = ofd.FileName;

                player.controls.play();

                label1.Text = "Currently playing " + title;
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MusicForm_Load(object sender, EventArgs e)
        {
            player.controls.stop();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            player.settings.volume = 0;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            player.controls.stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //OpenFileDialog dlg = new OpenFileDialog();
            //dlg.Multiselect = true;
            //if(dlg.ShowDialog() == DialogResult.OK)
            //{
            //    files = dlg.SafeFileNames;
            //    paths = dlg.FileNames;
            //    Mp3Lib.Mp3File mp3File = new Mp3Lib.Mp3File(dlg.FileName);
               
                

            //    listBox1.Visible = true;
            //    for (int i = 0; i < files.Length; i++)
            //    {
            //        artists[i] = mp3File.TagHandler.Artist[i].ToString();
            //        albums[i] = mp3File.TagHandler.Album[i].ToString();
            //        titles[i] = mp3File.TagHandler.Title[i].ToString();
            //        years[i] = mp3File.TagHandler.Year[i].ToString();
            //        tags2.Add(new TagsFolder { artist = artists[i], album = albums[i], title = titles[i], year = years[i] });
            //        dataGridView1.DataSource = tags2;
            //    }
                
            //}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //OpenFileDialog ofd2 = new OpenFileDialog();
            //ofd2.Multiselect = true;
            //if(ofd2.ShowDialog() == DialogResult.OK)
            //{
            //    files = ofd2.SafeFileNames;
            //    paths = ofd2.FileNames;
            //    listBox1.Visible = true;
            //    for (int i = 0; i < files.Length; i++)
            //    {
            //        listBox1.Items.Add(files[i]);
            //    }
            //}
            dataGridView1.Visible = true;
            dataGridView1.DataSource = tags;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            player.controls.play();
        }
    }
}
