using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Shared.DesignPattern;

namespace Challenge5
{
  public class GameManagerX : Singleton<GameManagerX>
  {
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private Button restartButton;
    [SerializeField] private List<GameObject> targetPrefabs;

    private int score;
    private float spawnRate = 1.5f;
    public bool isGameActive;

    private float spaceBetweenSquares = 2.5f;
    private float minValueX = -3.75f;
    private float minValueY = -3.75f;

    public void StartGame(LevelData data)
    {
      DisableScreen(titleScreen);
      ResetData();
      RefreshUI();
      spawnRate = data.spawnRate;
      StartCoroutine(SpawnTarget());
    }

    public void UpdateScore(int scoreToAdd)
    {
      score += scoreToAdd;
      RefreshUI();
    }

    public void GameOver()
    {
      isGameActive = false;
      gameOverText.gameObject.SetActive(true);
      restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ResetData()
    {
      score = 0;
      isGameActive = true;
    }

    private void RefreshUI()
    {
      scoreText.text = "Score: " + score;
    }

    private void DisableScreen(GameObject screen)
    {
      screen.SetActive(false);
    }

    private IEnumerator SpawnTarget()
    {
      while (isGameActive)
      {
        yield return new WaitForSeconds(spawnRate);
        int index = Random.Range(0, targetPrefabs.Count);

        if (!isGameActive) yield break;

        Vector3 spawnPos = RandomSpawnPosition();
        Instantiate(targetPrefabs[index], spawnPos, targetPrefabs[index].transform.rotation);
      }
    }

    private Vector3 RandomSpawnPosition()
    {
      var xIndex = RandomSquareIndex();
      float spawnPosX = minValueX + (xIndex * spaceBetweenSquares);

      var yIndex = RandomSquareIndex();
      float spawnPosY = minValueY + (yIndex * spaceBetweenSquares);

      Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0);
      return spawnPosition;
    }

    private int RandomSquareIndex()
    {
      return Random.Range(0, 4);
    }
  }
}