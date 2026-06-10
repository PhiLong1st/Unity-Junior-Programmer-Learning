using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
  public PlayerController player;
  public Vector3 cameraOffset = new Vector3(0, 5, -10);


  private void LateUpdate()
  {
    transform.position = player.transform.position + cameraOffset;
  }
}