using UnityEngine;
using UnityEngine.InputSystem;

namespace CourseLibraryPrototype2
{
  [RequireComponent(typeof(Rigidbody))]
  public class PlayerController : MonoBehaviour
  {
    [SerializeField] private InputAction _moveAction;
    [SerializeField] private InputAction _fireAction;

    public GameObject projectilePrefab;
    public float xRange = 10.0f;
    public float speed = 5f;

    void OnEnable()
    {
      _moveAction.Enable();
      _fireAction.Enable();
    }

    private void Update()
    {
      Vector2 horizontalInput = _moveAction.ReadValue<Vector2>();

      Vector3 newPosition = new Vector3(
        Mathf.Clamp(transform.position.x + horizontalInput.x * speed * Time.deltaTime, -xRange, xRange),
        transform.position.y,
        transform.position.z
      );
      transform.position = newPosition;

      if (_fireAction.triggered)
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
      _moveAction.Disable();
      _fireAction.Disable();
    }
  }
}
