using UnityEngine;
using System;

namespace CourseLibraryPrototype2
{
  public class Animal : MonoBehaviour
  {
    [SerializeField] private float _speed = 5f;

    public Action<Animal> OnDespawn;
    public Action<Animal> OnReachDestroyZone;

    private void Update()
    {
      MoveForward();
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.CompareTag(TagConstant.Player) || other.CompareTag(TagConstant.Food))
      {
        OnDespawn?.Invoke(this);
      }

      if (other.CompareTag(TagConstant.DestroyZone))
      {
        OnDespawn?.Invoke(this);
        OnReachDestroyZone?.Invoke(this);
        Debug.Log("Game Over!");
      }
    }

    private void MoveForward()
    {
      var newPosition = new Vector3(
          transform.position.x,
          transform.position.y,
          transform.position.z + _speed * Time.deltaTime
      );
      transform.position = newPosition;
    }
  }
}