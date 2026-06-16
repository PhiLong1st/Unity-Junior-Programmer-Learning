using UnityEngine;

namespace CourseLibraryPrototype2
{
  public class DestroyOutOfBounds : MonoBehaviour
  {
    [SerializeField] private float topBound = 30f;
    [SerializeField] private float lowerBound = -10f;

    private void Update()
    {
      if (IsOutOfBounds())
      {
        if (gameObject.CompareTag(TagConstant.Animal))
        {
          Debug.Log("Game Over!");
        }

        Destroy(gameObject);
      }
    }

    private bool IsOutOfBounds()
    {
      return transform.position.z > topBound || transform.position.z < lowerBound;
    }
  }
}