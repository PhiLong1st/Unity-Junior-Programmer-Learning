namespace Challenge5
{
  using UnityEngine;
  using Shared.DesignPattern;

  public enum GameState
  {
    MainMenu,
    Playing,
    GameOver
  }

  public class GameManager : Singleton<GameManager>
  {
    public int score { get; private set; }
    public bool IsGamePlaying => currentState == GameState.Playing;
    public bool IsPausing => currentState == GameState.GameOver;
    public GameState currentState { get; private set; }

    public void StartGame()
    {
      score = 0;
      currentState = GameState.Playing;
      Debug.Log($"Game Started!");
    }

    public void EndGame()
    {
      currentState = GameState.GameOver;
      Debug.Log($"Game Over! Final Score: {score}");
    }

    public void UpdateScore(int points)
    {
      score += points;
      Debug.Log($"Score Updated: {score}");
    }
  }
}