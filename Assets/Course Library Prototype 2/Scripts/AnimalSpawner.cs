using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;

namespace CourseLibraryPrototype2
{
  public class AnimalSpawner : MonoBehaviour
  {
    [SerializeField] private Animal[] animalPrefabs;
    [SerializeField] private float _spawnRangeX = 20f;
    [SerializeField] private float _startDelay = 2;
    [SerializeField] private float _spawnInterval = 1.5f;

    private Dictionary<int, IObjectPool<Animal>> _spawnedAnimals;

    private void Awake()
    {
      _spawnedAnimals = new Dictionary<int, IObjectPool<Animal>>();

      for (int idx = 0; idx < animalPrefabs.Length; idx++)
      {
        int prefabId = idx;

        _spawnedAnimals[prefabId] = new ObjectPool<Animal>(
            createFunc: () => CreateAnimal(prefabId),
            actionOnGet: (animal) => animal.gameObject.SetActive(true),
            actionOnRelease: (animal) => animal.gameObject.SetActive(false),
            actionOnDestroy: (animal) => Destroy(animal.gameObject)
        );
      }
    }

    private void Start()
    {
      InvokeRepeating(nameof(SpawnRandomAnimal), _startDelay, _spawnInterval);
    }

    public void SpawnRandomAnimal()
    {
      Vector3 spawnPosition = GetRandomSpawnPosition();

      int randomIndex = Random.Range(0, animalPrefabs.Length);
      Quaternion animalRotation = animalPrefabs[randomIndex].transform.rotation;

      Animal spawnedAnimal = _spawnedAnimals[randomIndex].Get();
      spawnedAnimal.transform.position = spawnPosition;
      spawnedAnimal.transform.rotation = animalRotation;
    }

    private Vector3 GetRandomSpawnPosition()
    {
      float randomX = Random.Range(-_spawnRangeX, _spawnRangeX);
      return new Vector3(randomX, transform.position.y, transform.position.z);
    }

    private Animal CreateAnimal(int prefabId)
    {
      Animal animal = Instantiate(animalPrefabs[prefabId]);
      animal.OnDespawn += (a) => _spawnedAnimals[prefabId].Release(a);
      return animal;
    }
  }
}