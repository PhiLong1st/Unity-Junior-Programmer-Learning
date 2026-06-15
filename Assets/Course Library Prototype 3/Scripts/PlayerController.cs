using UnityEngine;
using UnityEngine.InputSystem;

namespace CourseLibraryPrototype3
{
  [RequireComponent(typeof(Rigidbody))]
  public class PlayerController : MonoBehaviour
  {
    [SerializeField] private float _jumpForce = 100f;
    private Rigidbody _rigidbody;
    private bool _isGrounded = false;

    private bool _isGameOver = false;
    private Animator _animator;

    public InputAction jumpAction;
    public bool IsGameOver => _isGameOver;

    [SerializeField] private ParticleSystem _explosionParticle;
    [SerializeField] private ParticleSystem _groundParticle;


    private void Awake()
    {
      _rigidbody = GetComponent<Rigidbody>();
      _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
      jumpAction.Enable();
    }

    private void Update()
    {
      if (jumpAction.triggered && _isGrounded && !_isGameOver)
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
        _groundParticle.Play();
      }
      else if (collision.gameObject.CompareTag("Obstacle"))
      {
        _isGameOver = true;
        _animator.SetBool("Death_b", true);
        _animator.SetInteger("DeathType_int", 1);

        _explosionParticle.Play();
        _groundParticle.Stop();

        Debug.Log("Game Over!");
      }
    }

    private void OnJump()
    {
      _isGrounded = false;
      _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
      _animator.SetTrigger("Jump_trig");
    }
  }
}