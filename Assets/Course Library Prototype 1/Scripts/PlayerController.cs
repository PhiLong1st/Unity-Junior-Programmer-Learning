using UnityEngine;
using UnityEngine.InputSystem;

namespace CourseLibraryPrototype1
{
  [RequireComponent(typeof(Rigidbody))]
  public class PlayerController : MonoBehaviour
  {
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _turnSpeed = 100f;
    [SerializeField] private InputAction moveAction;

    private void OnEnable()
    {
      moveAction.Enable();
    }

    private void Update()
    {
      Vector2 moveInput = moveAction.ReadValue<Vector2>();

      transform.Translate(Vector3.forward * Time.deltaTime * _speed * moveInput.y);
      transform.Rotate(Vector3.up * Time.deltaTime * _turnSpeed * moveInput.x);
    }
  }
}