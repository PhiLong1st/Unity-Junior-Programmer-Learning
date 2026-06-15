using UnityEngine;

namespace Challenge1
{
  public class SpinPropellerX : MonoBehaviour
  {
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
      transform.Rotate(Vector3.forward * Time.deltaTime * _rotationSpeed);
    }
  }
}