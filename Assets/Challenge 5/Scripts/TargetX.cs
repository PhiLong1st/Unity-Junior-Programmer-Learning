using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Challenge5
{
  public class TargetX : MonoBehaviour
  {
    [SerializeField] private FoodData foodData;

    private FoodType _foodType;
    private int _pointValue;
    private GameObject _explosionFx;
    private float _timeOnScreen = 1.5f;

    private float minValueX = -3.75f;
    private float minValueY = -3.75f;
    private float spaceBetweenSquares = 2.5f;

    private void Initialize()
    {
      _foodType = foodData.foodType;
      _pointValue = foodData.pointValue;
      _explosionFx = foodData.explosionFx;
      _timeOnScreen = foodData.timeOnScreen;
    }

    private void Start()
    {
      Initialize();
      transform.position = RandomSpawnPosition();
      StartCoroutine(RemoveObjectRoutine());
    }

    private void Update()
    {
      if (GameManagerX.Instance.isGameActive && Mouse.current.leftButton.wasPressedThisFrame)
      {
        Destroy(gameObject);
        GameManagerX.Instance.UpdateScore(_pointValue);
        Explode();
      }
    }

    private Vector3 RandomSpawnPosition()
    {
      float spawnPosX = minValueX + (RandomSquareIndex() * spaceBetweenSquares);
      float spawnPosY = minValueY + (RandomSquareIndex() * spaceBetweenSquares);

      Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0);
      return spawnPosition;
    }

    private int RandomSquareIndex()
    {
      return Random.Range(0, 4);
    }

    private void OnTriggerEnter(Collider other)
    {
      Destroy(gameObject);

      if (other.gameObject.CompareTag("Sensor") && !gameObject.CompareTag("Bad"))
      {
        GameManagerX.Instance.GameOver();
      }
    }

    private void Explode()
    {
      Instantiate(_explosionFx, transform.position, _explosionFx.transform.rotation);
    }

    private IEnumerator RemoveObjectRoutine()
    {
      yield return new WaitForSeconds(_timeOnScreen);
      if (GameManagerX.Instance.isGameActive)
      {
        transform.Translate(Vector3.forward * 5, Space.World);
      }
    }
  }
}