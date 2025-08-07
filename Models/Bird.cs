using System.Windows.Forms;
using FB.Interfaces;

namespace FB.Models
{
    public class Bird : IBird
    {
        public PictureBox Sprite { get; private set; }
        private int gravity = 5;

        public Bird(PictureBox sprite)
        {
            Sprite = sprite;
        }

        public void Move()
        {
            Sprite.Top += gravity;
        }

        public void Flap()
        {
            gravity = -8;
        }

        public void Fall()
        {
            gravity = 5;
        }

        public void Reset()
        {
            Sprite.Top = 213;
            gravity = 5;
        }
    }
}
