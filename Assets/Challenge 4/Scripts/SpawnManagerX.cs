using UnityEngine;

namespace Challenge4
{
  public class SpawnManagerX : MonoBehaviour
  {
    private readonly Vector3 powerupSpawnOffset = new Vector3(0, 0, -15);

    [SerializeField] private PlayerControllerX player;

    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRangeX = 10;
    private float spawnZMin = 15;
    private float spawnZMax = 25;

    public int waveCount = 1;

    private void Awake()
    {
      if (player is null)
      {
        player = GameObject.Find("Player").GetComponent<PlayerControllerX>();
      }
    }

    private void Update()
    {
      bool isEnemyExist = CheckEnemyExist();
      if (isEnemyExist)
      {
        return;
      }

      SpawnEnemyWave(waveCount);

      bool isPowerupExist = CheckPowerupExist();
      if (!isPowerupExist)
      {
        SpawnPowerUp();
      }

      player.ResetPosition();
    }

    private Vector3 GenerateSpawnPosition()
    {
      float xPos = Random.Range(-spawnRangeX, spawnRangeX);
      float zPos = Random.Range(spawnZMin, spawnZMax);
      return new Vector3(xPos, 0, zPos);
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
      for (int i = 0; i < enemiesToSpawn; i++)
      {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
      }

      waveCount++;
    }

    private void SpawnPowerUp()
    {
      Vector3 spawnPos = GenerateSpawnPosition() + powerupSpawnOffset;
      Instantiate(powerupPrefab, spawnPos, powerupPrefab.transform.rotation);
    }

    private bool CheckEnemyExist()
    {
      return GameObject.FindGameObjectsWithTag("Enemy").Length > 0;
    }

    private bool CheckPowerupExist()
    {
      return GameObject.FindGameObjectsWithTag("Powerup").Length > 0;
    }
  }
}