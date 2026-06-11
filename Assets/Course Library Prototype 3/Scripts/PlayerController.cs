using UnityEngine;
using UnityEngine.InputSystem;

namespace CourseLibraryPrototype3
{
  [RequireComponent(typeof(Rigidbody))]
  public class PlayerController : MonoBehaviour
  {
    private Rigidbody _rigidbody;
    private float _jumpForce = 100f;
    private bool _isGrounded = false;

    public InputAction jumpAction;

    private void Awake()
    {
      _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
      jumpAction.Enable();
    }

    private void Update()
    {
      if (jumpAction.triggered && _isGrounded)
      {
        OnJump();
      }
    }

    private void OnDisable()
    {
      jumpAction.Disable();
    }

    private void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.CompareTag("Ground"))
      {
        _isGrounded = true;
      }
    }

    private void OnJump()
    {
      _isGrounded = false;
      _rigidbody.AddForce(Vector3.up * _jumpForce);
    }
  }
}