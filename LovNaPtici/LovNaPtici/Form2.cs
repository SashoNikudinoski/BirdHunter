﻿using LovNaPtici.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LovNaPtici
{
    public partial class Form2 : Form
    {
        public int highscore;
        public int score;
        public int totalScore;
        Random ran = new Random();
        public int Time;
        public string Username;
        int x1, y1;
        int x2, y2;
        int x3, y3;
        private SoundPlayer backgroundMusic;
        private SoundPlayer pistolSound;


        public Form2(string username)
        {
            
            InitializeComponent();
            Bitmap b = new Bitmap(LovNaPtici.Properties.Resources.CustomAim2);
            this.Cursor = CustomCursor.CreateCursor(b, b.Height / 2, b.Width / 2);
            Time = 15;
            DoubleBuffered = true;
            score = 0;
            totalScore = 0;
            Username = username;
            backgroundMusic = new SoundPlayer("BirdChirping.wav");
            pistolSound = new SoundPlayer("PistolSound.wav");
            lblTime.Text = string.Format("{0}", Time);
            timer1.Start();
            timer2.Start();


           
          
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
            x2 = ptica2.Location.X;
            y2 = ptica2.Location.Y;

            x3 = ptica3.Location.X;
            y3 = ptica3.Location.Y;


            if (x2 <= this.Width && x2 > 0)
            {

                x2 = x2 - 15;
              
            }

            if (x2 <= 0)
            {
                x2 = this.Width;
                if (score <= 0)
                {
                    score = 0;
                }
                else
                {
                    score-=3;
                }
                y2 = ran.Next(0, Height/12*2);
            }

            if (x3 <= this.Width && x3 > 0)
            {

                x3 = x3 - 22;
               

            }

            if (x3 <= 0)
            {
                x3 = this.Width;
                if (score <= 0)
                {
                    score = 0;
                }
                else
                {
                    score-=3;
                }
                y3 = ran.Next(Height / 12 * 6,Height / 12 * 8);

            }


            Proverka();
            ptica2.Location = new Point(x2, y2);
            ptica3.Location = new Point(x3, y3);
            RefreshScores();

        }

    
        private void ptica1_MouseClick(object sender, MouseEventArgs e)
        {
            ptica1.Hide();
            pistolSound.Play();
            x1 = 0;
            ptica1.Location = new Point(x1,ran.Next(Height / 12 * 3, Height / 12 * 5));
            ptica1.Show();
            score+=5;
            Proverka();
            RefreshScores();
           

        }

        private void ptica2_MouseClick(object sender, MouseEventArgs e)
        {
            ptica2.Hide();
            pistolSound.Play();
            x2 = this.Width;
            ptica2.Location = new Point(x2, ran.Next(0, Height / 12 * 2));
            ptica2.Show();
            score+=3;
            Proverka();
            RefreshScores();
           

        }

        private void ptica3_MouseClick(object sender, MouseEventArgs e)
        {
            ptica3.Hide();
            pistolSound.Play();
            x3 = this.Width;
            ptica3.Location = new Point(x3,ran.Next(Height / 12 *6,Height / 12 * 8));
            ptica3.Show();
            score+=3;
            Proverka();
            RefreshScores();
           
        }



        public void Proverka()
        {
            if (Time > 0 && score <= 0)
            {
                score = 0;

            }
            if (score >= 45 && Time > 0)
            {

                btnNext.Visible = true;
              
            }

            else if (Time == 0)
            {
                if (score >= 45)
                {

                    ptica1.Hide();
                    ptica2.Hide();
                    ptica3.Hide();
                    timerTimeLeft.Stop();
                    timer1.Stop();
                    timer2.Stop();
                }
                else
                {
                    btnGameOver.Visible = true;
                    lblGameOver.Visible = true;
                    ptica1.Hide();
                    ptica2.Hide();
                    ptica3.Hide();
                    timerTimeLeft.Stop();
                    timer1.Stop();
                    timer2.Stop();
                    HighScores h = new HighScores();
                    Player p1 = new Player();
                    p1.username = Username;
                    p1.score = totalScore;
                    h.addPlayer(p1);
                    h.Save();

                   
                  
                 
                }
            }

        }

      

        public void RefreshScores()
        {

            lblSc.Text = score.ToString();
            totalScore = score;
            lblTs.Text = totalScore.ToString();



        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblTs.Text = "0";
            lblSc.Text = "0";
            backgroundMusic.Play();
            timerTimeLeft.Start();


        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(Username,totalScore);
            this.Hide();
            form3.Show();

        }

       

        private void timerTimeLeft_Tick(object sender, EventArgs e)
        {
            
            Time--;
            lblTime.Text = string.Format("{0}", Time);
            Proverka();
           
        }

        private void btnGameOver_Click(object sender, EventArgs e)
        {
            Form1 nazad = new Form1();
            nazad.StartPosition = FormStartPosition.Manual;
            nazad.Location = this.Location;
            nazad.Show(this);
            Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x1 = ptica1.Location.X;
            y1 = ptica1.Location.Y;
            if (x1 < this.Width && (x1 > 0 || x1 == 0))
            {

                x1 = x1 + 20;

            }

            if (x1 > this.Width)
            {
                x1 = 0;
                if (score <= 0)
                {
                    score = 0;
                }
                else
                {
                    score-=5;
                }
                y1 = ran.Next(Height / 12 * 3, Height / 12 * 5);
            }

            Proverka();
            ptica1.Location = new Point(x1, y1);
            RefreshScores();


        }

        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void Form2_Click(object sender, EventArgs e)
        {
            pistolSound.Play();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            backgroundMusic.Stop();
        }



    }
}
