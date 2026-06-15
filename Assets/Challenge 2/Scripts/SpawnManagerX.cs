using UnityEngine;

namespace Challenge2
{
  public class SpawnManagerX : MonoBehaviour
  {
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    private void Start()
    {
      InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    private void SpawnRandomBall()
    {
      Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
      Instantiate(ballPrefabs[0], spawnPos, ballPrefabs[0].transform.rotation);
    }
  }
}