using UnityEngine;

namespace CourseLibraryPrototype4
{
  public class WaveSpawner : MonoBehaviour
  {
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private GameObject powerupPrefab;
    [SerializeField] private float spawnRange = 5f;
    [SerializeField] private int wave = 0;

    private void Update()
    {
      bool isEnemyExist = CheckEnemyExist();
      if (!isEnemyExist)
      {
        ++wave;
        SpawnEnemy(wave);

        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
      }
    }

    private bool CheckEnemyExist()
    {
      var enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
      return enemyCount > 0;
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
      return new Vector3(randomX, -1.2f, randomZ);
    }
  }
}