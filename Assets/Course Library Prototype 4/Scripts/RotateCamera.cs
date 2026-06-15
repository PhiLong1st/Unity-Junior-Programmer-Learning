using UnityEngine;

namespace CourseLibraryPrototype4
{
  public class RotateCameraX : MonoBehaviour
  {
    [SerializeField] private float speed = 200;
    [SerializeField] private PlayerController player;

    private void Update()
    {
      float horizontalInput = Input.GetAxis("Horizontal");
      transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);
      transform.position = player.transform.position;
    }
  }
}