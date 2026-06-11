using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  public GameObject enemyPrefab;
  public float spawnRange = 5f;


  private void Start()
  {
    SpawnEnemy(3);
  }

  private void SpawnEnemy(int enemyCount)
  {
    for (int i = 0; i < enemyCount; ++i)
    {
      Vector3 spawnPos = GenerateSpawnPosition();
      Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
    }
  }

  private Vector3 GenerateSpawnPosition()
  {
    float randomX = Random.Range(-spawnRange, spawnRange);
    float randomZ = Random.Range(-spawnRange, spawnRange);
    return new Vector3(randomX, 0, randomZ);
  }
}