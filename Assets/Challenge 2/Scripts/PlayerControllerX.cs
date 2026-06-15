using UnityEngine;

namespace Challenge2
{
  public class PlayerControllerX : MonoBehaviour
  {
    public GameObject dogPrefab;

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
      }
    }
  }
}
