using FB.Interfaces;
using System;
using System.Windows.Forms;

namespace FB.Models
{
    public class PipePair : IPipe
    {
        public PictureBox TopPipe { get; private set; }
        public PictureBox BottomPipe { get; private set; }
        private int speed;
        private int groundHeight;
        private Random rnd = new Random();

        public PipePair(PictureBox top, PictureBox bottom, int groundHeight, int initialSpeed)
        {
            TopPipe = top;
            BottomPipe = bottom;
            this.groundHeight = groundHeight;
            speed = initialSpeed;
        }

        public void Move()
        {
            TopPipe.Left -= speed;
            BottomPipe.Left -= speed;
        }

        public void Reposition(int newX)
        {
            int topHeight = rnd.Next(50, 200);
            TopPipe.Height = topHeight;
            TopPipe.Top = 0;

            BottomPipe.Top = topHeight + 130;
            BottomPipe.Height = 450 - BottomPipe.Top - groundHeight;

            TopPipe.Left = newX;
            BottomPipe.Left = newX;
        }

        public void SetSpeed(int newSpeed)
        {
            speed = newSpeed;
        }

        public bool IsOffScreen()
        {
            return BottomPipe.Left < -60;
        }

        public bool CollidesWith(Control obj)
        {
            return obj.Bounds.IntersectsWith(TopPipe.Bounds) || obj.Bounds.IntersectsWith(BottomPipe.Bounds);
        }

        public void ResetPosition(int x)
        {
            TopPipe.Left = x;
            BottomPipe.Left = x;
        }
    }
}
