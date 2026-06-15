using UnityEngine;

namespace CourseLibraryPrototype2
{
  public class DetectCollisions : MonoBehaviour
  {
    private void OnTriggerEnter(Collider other)
    {
      if (other.CompareTag("Player"))
      {
        return;
      }

      Destroy(gameObject);
      Destroy(other.gameObject);
    }
  }
}