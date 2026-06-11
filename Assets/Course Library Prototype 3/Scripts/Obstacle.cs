using UnityEngine;

public class Obstacle : MonoBehaviour
{
  private float speed = 30;
  private float _rightBoundX = 50;
  private float _leftBoundX = -50;

  void Update()
  {
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
}