using UnityEngine;

namespace CourseLibraryPrototype3
{
  public class SpawnManager : MonoBehaviour
  {
    [SerializeField] private PlayerController _playerController;

    public Obstacle[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;

    void Start()
    {
      InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    private void Update()
    {
      if (_playerController == null || _playerController.IsGameOver)
      {
        CancelInvoke("SpawnObstacle");
      }
    }

    void SpawnObstacle()
    {
      int randomIndex = Random.Range(0, obstaclePrefabs.Length);
      var prefab = obstaclePrefabs[randomIndex].gameObject;

      Instantiate(prefab, spawnPos, prefab.transform.rotation);
    }
  }
}