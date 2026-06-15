using UnityEngine;

namespace CourseLibraryPrototype3
{
  public class Obstacle : MonoBehaviour
  {
    private float speed = 30;
    private float _rightBoundX = 50;
    private float _leftBoundX = -50;

    private bool _isGameOver = false;

    void Update()
    {
      if (_isGameOver)
      {
        return;
      }

      MoveLeft();
      HandleOnReachBound();
    }

    private void MoveLeft()
    {
      transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    private void HandleOnReachBound()
    {
      if (_leftBoundX < transform.position.x && transform.position.x < _rightBoundX)
      {
        return;
      }

      Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.CompareTag("Player"))
      {
        _isGameOver = true;
      }
    }
  }
}