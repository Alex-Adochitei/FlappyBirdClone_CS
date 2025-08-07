using FB.Interfaces;
using FB.Models;
using System;
using System.Windows.Forms;

namespace FB 
{
    public partial class Form1 : Form
    {
        private IBird bird;
        private IPipe pipes;
        private IGameManager gameManager;

        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += gameKeyDown;
            this.KeyUp += gameKeyUp;
            gameTimer.Tick += gameTimer_Tick;

            bird = new Bird(flappyBird);
            pipes = new PipePair(pipeTop, pipeBottom, ground.Height, 8);
            gameManager = new GameManager(scoreText, gameTimer);

            gameTimer.Interval = 20;
            gameTimer.Start();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (gameManager.IsGameOver) return;

            bird.Move();
            pipes.Move();
            pipes.SetSpeed(gameManager.GetPipeSpeed());

            if (pipes.IsOffScreen())
            {
                pipes.Reposition(500);
                gameManager.UpdateScore();
            }

            if (((Bird)bird).Sprite.Bounds.IntersectsWith(ground.Bounds) ||
                pipes.CollidesWith(((Bird)bird).Sprite) ||
                ((Bird)bird).Sprite.Top < 0)
            {
                gameManager.ShowGameOver();
            }
        }

        private void gameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (gameManager.IsGameOver)
                {
                    RestartGame();
                }
                else
                {
                    bird.Flap();
                }
            }
        }

        private void gameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                bird.Fall();
            }
        }

        private void RestartGame()
        {
            bird.Reset();
            pipes.ResetPosition(397);
            gameManager.Reset();
        }

        private void Form1_Load(object sender, EventArgs e) { }
    }
}
