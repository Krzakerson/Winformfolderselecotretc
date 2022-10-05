using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Forms;
using WinFormsApp2.Models;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

           

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            DateTime dateTime1 = dateTimePicker1.Value;
            DateTime dateTime2 = dateTimePicker2.Value;



            TimeSpan timeSpan = dateTime2 - dateTime1;


            double days = timeSpan.TotalDays;

            double hours = timeSpan.TotalHours;
            double minutes = timeSpan.TotalMinutes;
            double seconds = timeSpan.TotalSeconds;
            int daysint = Convert.ToInt32(days);
            int hoursint = Convert.ToInt32(hours);
            int minutesint = Convert.ToInt32(minutes);
            int secondsint = Convert.ToInt32(seconds);
            int weeks = daysint / 7;
            int months = daysint / 30;
            //richTextBox1.Text = comboBox1.GetItemText(comboBox1.SelectedIndex);
            string choice = comboBox1.GetItemText(comboBox1.SelectedIndex);
            int choiceint = Convert.ToInt32(choice);
            richTextBox1.Text = choiceint.ToString();
            if (choiceint == 0)
            {
                richTextBox1.Text = "W dniach " + daysint.ToString();
            }
            else if(choiceint == 1)
            {
                richTextBox1.Text = "W tygodniach " + weeks.ToString();
            }

            else if (choiceint == 2)
            {
                richTextBox1.Text = "W miesiacach " + months.ToString();
            }

            else if (choiceint == 3)
            {
                richTextBox1.Text = "W godzinach " + hoursint.ToString();
            }

            else if (choiceint == 4)
            {
                richTextBox1.Text = "W minutach " + minutesint.ToString();
            }

            else if (choiceint == 5)
            {
                richTextBox1.Text = "W sekundach " + secondsint.ToString();
            }

        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void selectFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;

                DateTime FileCreation = File.GetCreationTime(path);
                DateTime FileModification = File.GetLastWriteTime(path);


              

                TimeSpan timeSpan =  DateTime.Now - FileCreation;

                double difffile = timeSpan.TotalDays;

                int difffileint = Convert.ToInt32(difffile);

                richTextBox2.Text = "Data utworzenie" + FileCreation.ToString()+"\n" +
                 "Data modyfikacji" + FileModification.ToString() + "\n" +  "Ró¿nica miêdzy utowrzeniem a dzisiejsza dat¹ " + difffileint.ToString();


            }
        }

        private void selectFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                int filescount = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*", SearchOption.AllDirectories).Length;

                List<Datafolder> list = new List<Datafolder> {};
                string[] files = Directory.GetFiles(folderBrowserDialog.SelectedPath);
                DateTime filecreation = Directory.GetCreationTime(files[1]);
                TimeSpan daysdiff = DateTime.Now - filecreation;
                double diff = daysdiff.TotalDays;
                int diffint = Convert.ToInt32(diff);
             

                label5.Text = diffint.ToString();
                //DateTime[] filecreationarr =  Directory.GetCreationTime(files);
                
                List<DateTime> foldersdates = new List<DateTime>();

                List<TimeSpan> timeSpans = new List<TimeSpan>();

                List<Double> difffiledays = new List<Double>();




                //listBox1.Items.Add(filescount);

                foreach (var file in files)
                {
                    for(int i = 0; i < filescount/2; i++)
                    {
                        foldersdates.Add(Directory.GetCreationTime(file));

                        timeSpans.Add(DateTime.Now - foldersdates[i]);

                        difffiledays.Add(timeSpans[i].TotalDays);

                        //difffileintdays.Add(Convert.ToInt32(difffileintdays[i]));

                        list.Add(new Datafolder { Dni = Convert.ToInt32(difffiledays[i]), NazwaPliku = file, WhenCreated = Directory.GetCreationTime(file) });
                    }


                   
                    
                }

                dataGridView1.DataSource = list;

                //foreach(var foldersdate in foldersdates)
                //{
                //    listBox1.Items.Add(foldersdate);
                //}

                //foreach(string file in files)
                //{
                //    listBox1.Items.Add(file);
                //}


                //osobny model oraz roznica miedzy data utworzenia a dzisiejsza 



            }

         

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            

            
        }

        private void clearRichtextboxesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

       private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        } 

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openMusicFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MusicForm musicForm = new MusicForm();
            musicForm.ShowDialog();
        }
    }
}