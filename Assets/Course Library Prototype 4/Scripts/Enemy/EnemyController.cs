using UnityEngine;

namespace CourseLibraryPrototype4
{
  public class EnemyController : MonoBehaviour
  {
    public float enemySpeed = 150f;
    private GameObject _player;
    private Rigidbody _enemyRb;

    private bool _isOnGround = false;

    private void Awake()
    {
      _enemyRb = GetComponent<Rigidbody>();
      _player = GameObject.Find("Player");
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

    private void Update()
    {
      Vector3 lookDirection = (_player.transform.position - transform.position).normalized;
      _enemyRb.AddForce(lookDirection * enemySpeed * Time.deltaTime);

      if (!_isOnGround)
      {
        Destroy(gameObject);
        Debug.Log("Enemy Destroyed");
      }
    }
  }
}