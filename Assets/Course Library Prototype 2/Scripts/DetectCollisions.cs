using UnityEngine;

namespace CourseLibraryPrototype2
{
  public class DetectCollisions : MonoBehaviour
  {
    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
      Debug.Log("Collided with: " + other.gameObject.name);
      Destroy(gameObject);
      Destroy(other.gameObject);
    }
  }
}