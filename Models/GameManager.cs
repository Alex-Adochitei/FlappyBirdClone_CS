using System.Windows.Forms;
using FB.Interfaces;

namespace FB.Models
{
    public class GameManager : IGameManager
    {
        public int Score { get; private set; } = 0;
        public bool IsGameOver { get; private set; } = false;

        private Label scoreLabel;
        private Timer timer;

        public GameManager(Label label, Timer gameTimer)
        {
            scoreLabel = label;
            timer = gameTimer;
        }

        public void UpdateScore()
        {
            Score++;
            scoreLabel.Text = "Score: " + Score;
        }

        public void ShowGameOver()
        {
            IsGameOver = true;
            timer.Stop();
            scoreLabel.Text = $"Game Over! Final score: {Score} (Press SPACE to restart)";
        }

        public void Reset()
        {
            Score = 0;
            IsGameOver = false;
            scoreLabel.Text = "Score: 0";
            timer.Start();
        }

        public int GetPipeSpeed()
        {
            if (Score > 10) return 17;
            if (Score > 5) return 15;
            return 12;
        }
    }
}
