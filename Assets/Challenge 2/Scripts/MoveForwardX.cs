using UnityEngine;

namespace Challenge2
{
  public class MoveForwardX : MonoBehaviour
  {
    [SerializeField] private float _speed;

    private void Update()
    {
      transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
  }
}