using UnityEngine;

namespace CourseLibraryPrototype4
{
  public class Enemy : MonoBehaviour
  {
    [SerializeField] private PlayerController _player;
    public float enemySpeed = 150f;
    private Rigidbody _enemyRb;

    private bool _isOnGround = false;

    private void Awake()
    {
      _enemyRb = GetComponent<Rigidbody>();
      _player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.CompareTag("Ground"))
      {
        _isOnGround = true;
      }
    }

    private void OnCollisionExit(Collision collision)
    {
      if (collision.gameObject.CompareTag("Ground"))
      {
        _isOnGround = false;
      }
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag("DestroyZone"))
      {
        Destroy(gameObject);
      }
    }

    private void Update()
    {
      ChaseTo(_player);
    }

    private void ChaseTo(PlayerController target)
    {
      Vector3 lookDirection = (target.transform.position - transform.position).normalized;
      _enemyRb.AddForce(lookDirection * enemySpeed * Time.deltaTime);
    }
  }
}