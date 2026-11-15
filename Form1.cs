using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        int score = 0;
        int appleX, appleY;
        List<Cerc> snake = new List<Cerc>();

        Color nokiaDark = Color.FromArgb(43, 50, 25);
        Color nokiaLight = Color.FromArgb(143, 170, 113);

        Cerc apple;
        Random rnd;

        bool right = false, left = false, up = false, down = false;

        public Form1()
        {
            InitializeComponent();

            pictureBox1.BackColor = nokiaLight;

            this.BackColor = nokiaDark;

            button1.BackColor = nokiaLight;
            button1.ForeColor = nokiaDark;
            button1.FlatStyle = FlatStyle.Flat;

            button2.BackColor = nokiaLight;
            button2.ForeColor = nokiaDark;
            button2.FlatStyle = FlatStyle.Flat;

            label1.ForeColor = nokiaLight;
            label2.ForeColor = nokiaLight;

            apple = new Cerc(50, 50, nokiaDark);
            rnd = new Random();
            label1.Text = "SCORE: 0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void RestartGame()
        {
            snake.Clear();

            snake.Add(new Cerc(10, 10, nokiaDark));
            snake.Add(new Cerc(9, 10, nokiaDark));
            snake.Add(new Cerc(8, 10, nokiaDark));
            snake.Add(new Cerc(7, 10, nokiaDark));

            SpawnApple();

            left = false; up = false; down = false;
            right = true;

            score = 0;
            label1.Text = "SCORE: " + score;

            button1.Enabled = false;

            this.ActiveControl = null;

            timer1.Start();
        }

        private void SpawnApple()
        {
            int maxGridX = pictureBox1.Width / 20;
            int maxGridY = pictureBox1.Height / 20;

            appleX = rnd.Next(0, maxGridX);
            appleY = rnd.Next(0, maxGridY);

            apple.X = appleX;
            apple.Y = appleY;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && !right) { left = true; up = false; down = false; }
            if (e.KeyCode == Keys.D && !left) { right = true; up = false; down = false; }
            if (e.KeyCode == Keys.W && !down) { up = true; left = false; right = false; }
            if (e.KeyCode == Keys.S && !up) { down = true; left = false; right = false; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            for (int i = snake.Count - 1; i >= 1; i--)
            {
                snake[i].X = snake[i - 1].X;
                snake[i].Y = snake[i - 1].Y;
            }

            if (right) snake[0].X++;
            if (left) snake[0].X--;
            if (up) snake[0].Y--;
            if (down) snake[0].Y++;

            int maxX = (pictureBox1.Width / 20) - 1;
            int maxY = (pictureBox1.Height / 20) - 1;

            if (snake[0].X < 0) snake[0].X = maxX;
            if (snake[0].X > maxX) snake[0].X = 0;
            if (snake[0].Y < 0) snake[0].Y = maxY;
            if (snake[0].Y > maxY) snake[0].Y = 0;

            if (snake[0].X == appleX && snake[0].Y == appleY)
            {
                score += 10;
                label1.Text = "SCORE: " + score;

                Cerc newSegment = new Cerc(snake[snake.Count - 1].X, snake[snake.Count - 1].Y, nokiaDark);
                snake.Add(newSegment);

                SpawnApple();
            }

            for (int i = 1; i < snake.Count; i++)
            {
                if (snake[0].X == snake[i].X && snake[0].Y == snake[i].Y)
                {
                    GameOver();
                    return;
                }
            }

            pictureBox1.Invalidate();
        }

        private void GameOver()
        {
            timer1.Stop();
            button1.Enabled = true;
            MessageBox.Show("GAME OVER!\nFINAL SCORE: " + score);
        }

        private void deseneaza(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            apple.DrawAsApple(g);

            for (int i = 0; i < snake.Count; i++)
            {
                if (i == 0)
                {
                    snake[i].DrawAsHead(g, pictureBox1.BackColor);
                }
                else
                {
                    snake[i].DrawAsBody(g, pictureBox1.BackColor);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
    }
}