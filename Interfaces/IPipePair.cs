using System.Windows.Forms;

namespace FB.Interfaces
{
    public interface IPipe
    {
        void Move();
        void Reposition(int x);
        void SetSpeed(int speed);
        bool IsOffScreen();
        bool CollidesWith(Control control);
        void ResetPosition(int x);
    }
}
