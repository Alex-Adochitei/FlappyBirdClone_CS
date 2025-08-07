namespace FB.Interfaces
{
    public interface IGameManager
    {
        int Score { get; }
        bool IsGameOver { get; }
        void UpdateScore();
        void ShowGameOver();
        void Reset();
        int GetPipeSpeed();
    }
}
