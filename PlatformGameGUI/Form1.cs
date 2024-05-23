using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlatformGameGUI
{
    public partial class Form1 : Form
    {
        //declare constants
        const int G = 30;
        //declare variables
        bool right;
        bool left;
        bool up;
        bool down;
        bool jump;
        bool fall;
        int force;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if ( player.Right > block.Left  && player.Right <= block.Right && player.Bottom > block.Top)
            //{
            //    right = false;
            //}
            //if (player.Left < block.Right && player.Left > block.Left && player.Bottom > block.Top)
            //{
            //    left = false;
            //}
            if (player.Bounds.IntersectsWith(block.Bounds))
            {
                right = false;
            }
            if (player.Left < block.Right && player.Left > block.Left && player.Bottom > block.Top)
            {
                left = false;
            }

            //if (player.Right > block.Left && player.Right < block.Right && player.Bottom > block.Top)
            //{
            //    block.Top = player.Bottom;
            //    jump = false;
            //
            //}

            //if (player.Right > block.Left && player.Right < block.Right && player.Bounds.IntersectsWith(block.Bounds))
            //{
            //    block.Top = player.Bottom;
            //    jump = false;
            //
            //}


            if (right == true)
            {
                player.Left += 5;

            }
            else if (left == true)
            {
                player.Left -= 5;
            }
            else if (up == true)
            {
                player.Top -= 5;
            }
            else if (down == true)
            {
                player.Top += 5;
            }

            if (jump == true)
            {
                player.Top -= force;
                force -= 1;
                
            }
            
            if (player.Right < block.Left || player.Right > block.Right && jump == true)
            {
                
                if (player.Bottom >= screen.Height)
                {
                    player.Top = screen.Height - player.Height;
                    jump = false;
                }
            }
            


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                    right = true;
            }
            else if (e.KeyCode == Keys.Left)
            {
                left = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                up = true;

            }
            else if (e.KeyCode == Keys.Down)
            {
                down = true;

            }
            if (jump != true)
            {
                if (e.KeyCode == Keys.Space)
                {
                    jump = true;
                    force = G;
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = false;

            }
            else if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
            else if (e.KeyCode == Keys.Up)
            {
                up = false;

            }
            else if (e.KeyCode == Keys.Down)
            {
                down = false;

            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            
        }
    }
}
