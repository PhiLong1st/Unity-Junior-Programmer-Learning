using UnityEngine;

namespace CourseLibraryPrototype2
{
  public class DestroyOutOfBounds : MonoBehaviour
  {
    public float topBound = 30f;
    public float lowerBound = -10f;

    private void Update()
    {
      if (transform.position.z > topBound || transform.position.z < lowerBound)
      {
        if (gameObject.CompareTag("Animal"))
        {
          Debug.Log("Game Over!");
        }

        Destroy(gameObject);
      }
    }
  }
}