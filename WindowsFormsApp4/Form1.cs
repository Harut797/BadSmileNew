using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.TransparencyKey = Color.White;
           this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            InitializeComponent();
            GameStart();
        }
        //private void CreateDynamicButton()
        //{
        //    Button dynamicButton = new Button();
        //    dynamicButton.Height = 40;
        //    dynamicButton.Width = 300;
        //    dynamicButton.BackColor = Color.Red;
        //    dynamicButton.ForeColor = Color.Blue;
        //    dynamicButton.Location = new Point(20, 150);
        //    dynamicButton.Text = "Click me!)";
        //    dynamicButton.Name = "DynamicButton";
        //    dynamicButton.Click += new EventHandler(DynamicButton_Click);
        //    Controls.Add(dynamicButton);
        //}
        static System.Media.SoundPlayer pplayer = new System.Media.SoundPlayer(@"audio\fon.wav");
        static GameResource Game = new GameResource();
        static Smile GameSmile = new Smile();
        static int SmileSpeed = 4;
        //public void DynamicButton_Click(object sender, EventArgs e)
        //{
        //    GameStart();
        //}
        public void GameStart()
        {
            Thread.Sleep(50);
            timer1.Enabled = true;
            GameResource Game = new GameResource()
            {
                x = 500,
                y = 500,
                k = 0,
                mousex = 0,
                mousey = 0,
                n = 0,
                counter = 0
            };
            Smile GameSmilee = new Smile()
            {
                formtop = 0,
                formleft = 0,
                padx = 0,
                pady = 0,
                padronx = 0,
                padrony = 0,
                smilehpp = 100,
                mousehpp = 100,
                padqanak = 0,
            };
            //this.Location = new Point(100, 100);
            pplayer.Play();
            Control control = new Control();
            Point coordinate = new Point(500);
        }
        public int RandomNumber(int num1,int num2)
        {
            Random rnd = new Random();
            return rnd.Next(num1, num2);
        }
        public void Strike()
        {
            GameSmile.padqanak++;
            var myForm = new Form2();
            myForm.Show();
            myForm.Location = new Point(Game.x, Game.y);
            GameSmile.padx = Game.mousex;
            GameSmile.pady = Game.mousey;
            GameSmile.padronx = Game.x;
            GameSmile.padrony = Game.y;
            for (int u = 0; u < 120; u++)
            {
                if (GameSmile.padronx < GameSmile.padx)
                {
                    GameSmile.padronx = GameSmile.padronx + 8;
                }
                else
                {
                    GameSmile.padronx -= 8;
                }
                if (GameSmile.padrony < GameSmile.pady)
                {
                    GameSmile.padrony += 8;
                }
                else
                {
                    GameSmile.padrony -= 8;
                }
                myForm.Location = new Point(GameSmile.padronx - 50, GameSmile.padrony - 50);
                Thread.Sleep(1);
            }
            myForm.TransparencyKey = Color.White;
            myForm.BackColor = Color.White;
            GameSmile.padx = Cursor.Position.X;
            GameSmile.pady = Cursor.Position.Y;
            if (GameSmile.padronx - 50 >= GameSmile.padx - 80 && GameSmile.padronx - 50 <= GameSmile.padx + 80 && GameSmile.padrony - 50 >= GameSmile.pady - 80 && GameSmile.padrony - 50 <= GameSmile.padrony + 80)
            {
                myForm.Refresh();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"audio\haha.wav");
                player.Play();
                timer1.Enabled = false;
                for (int b = 0; b < 100; b++)
                {
                    if (b == 1)
                    {
                        this.Refresh();
                    }
                    Cursor.Position = new Point(Game.mousex, Game.mousey);
                    Thread.Sleep(100);
                }
                string messages = "!!!";
                string titles = "Vernagir";
                MessageBox.Show(messages, titles);
                timer1.Enabled = true;
                pplayer.Play();
                GameSmile.mousehpp -= 10;
                smilehp.Text = GameSmile.smilehpp.ToString();
                mousehp.Text = GameSmile.mousehpp.ToString();
                if (GameSmile.mousehpp == 0)
                {
                    string messagesz = "Game Over";
                    string titlesz = "Game Over";
                    MessageBox.Show(messagesz, titlesz);
                    this.Close();
                    return;
                }
            }
            else
            {
                this.Refresh();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Game.n = RandomNumber(1, 300);
            Game.counter++;
            GameSmile.formleft = this.Left;
            GameSmile.formtop = this.Top;
            Game.mousex = Cursor.Position.X;
            Game.mousey = Cursor.Position.Y;
            if (GameSmile.formleft < Game.mousex)
            {
                if (GameSmile.formleft != Game.mousex)
                {
                    Game.x+=SmileSpeed;
                }
                else
                {
                    this.Refresh();
                    Thread.Sleep(2000);
                    Game.n = 3;
                }
            }
            else
            {
                Game.x-= SmileSpeed;
            }
            if (GameSmile.formtop < Game.mousey)
            {
                if (GameSmile.formleft != Game.mousex)
                {
                    Game.y+= SmileSpeed;
                }
                else
                {
                    this.Refresh();
                    Thread.Sleep(2000);
                    Game.n = 3;
                }
            }
            else
            {
                Game.y-= SmileSpeed;
            }
            Game.k++;
            this.Location = new Point(Game.x, Game.y);
            Thread.Sleep(5);
            if (Game.n == 38)
            {
                Strike();
            }
            if (GameSmile.formleft == Game.mousex && GameSmile.formtop == Game.mousey)
            {
                string messagesz = "Game Over";
                string titlesz = "Game Over";
                MessageBox.Show(messagesz, titlesz);
                this.Close();
                return;
            }
        }

    }
}
