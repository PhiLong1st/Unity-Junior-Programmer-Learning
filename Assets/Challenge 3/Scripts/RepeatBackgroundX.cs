using UnityEngine;

namespace Challenge3
{
  public class RepeatBackgroundX : MonoBehaviour
  {
    [SerializeField] private PlayerControllerX _player;
    private Vector3 startPos;
    private float repeatWidth;

    private void Start()
    {
      startPos = transform.position;
      repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    private void Update()
    {
      if (_player.gameOver) return;

      if (transform.position.x < startPos.x - repeatWidth)
      {
        transform.position = startPos;
      }
    }
  }
}


