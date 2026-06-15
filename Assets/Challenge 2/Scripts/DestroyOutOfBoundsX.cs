using UnityEngine;

namespace Challenge2
{
  public class DestroyOutOfBoundsX : MonoBehaviour
  {
    private float leftLimit = 30;
    private float bottomLimit = -5;

    private void Update()
    {
      if (transform.position.x > leftLimit)
      {
        Destroy(gameObject);
      }
      else if (transform.position.z < bottomLimit)
      {
        Destroy(gameObject);
      }

    }
  }
}