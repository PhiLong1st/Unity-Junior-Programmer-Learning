using UnityEngine;

namespace CourseLibraryPrototype1
{
  public class FollowPlayer : MonoBehaviour
  {
    [SerializeField] private PlayerController _player;
    [SerializeField] private Vector3 cameraOffset = new Vector3(0, 5, -10);

    private void LateUpdate()
    {
      transform.position = _player.transform.position + cameraOffset;
    }
  }
}