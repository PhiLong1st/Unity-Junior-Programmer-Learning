using UnityEngine;
using UnityEngine.InputSystem;

namespace CourseLibraryPrototype2
{
  [RequireComponent(typeof(Rigidbody))]
  public class PlayerController : MonoBehaviour
  {
    public GameObject projectilePrefab;

    public float xRange = 10.0f;
    public float speed = 5f;
    public InputAction moveAction;
    public InputAction fireAction;

    void OnEnable()
    {
      moveAction.Enable();
      fireAction.Enable();
    }

    void Update()
    {
      Vector2 horizontalInput = moveAction.ReadValue<Vector2>();

      Vector3 newPosition = new Vector3(
        Mathf.Clamp(transform.position.x + horizontalInput.x * speed * Time.deltaTime, -xRange, xRange),
        transform.position.y,
        transform.position.z
      );
      transform.position = newPosition;

      if (fireAction.triggered)
      {
        Fire();
      }
    }

    private void Fire()
    {
      Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    }

    private void OnDisable()
    {
      moveAction.Disable();
      fireAction.Disable();
    }
  }
}
