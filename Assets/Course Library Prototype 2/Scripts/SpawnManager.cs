using UnityEngine;
using UnityEngine.InputSystem;

namespace CourseLibraryPrototype2
{
  public class SpawnManager : MonoBehaviour
  {
    public GameObject[] animalPrefabs;
    public float spawnRangeX = 20f;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    void Start()
    {
      InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    private void SpawnRandomAnimal()
    {
      Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), transform.position.y, transform.position.z);

      int randomIndex = Random.Range(0, animalPrefabs.Length);
      GameObject animalPrefab = animalPrefabs[randomIndex];
      Quaternion animalRotation = animalPrefab.transform.rotation;

      Instantiate(animalPrefab, spawnPosition, animalRotation);
    }
  }
}