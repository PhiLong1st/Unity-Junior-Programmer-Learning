using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Challenge1
{
  public class FollowPlayerX : MonoBehaviour
  {
    public GameObject plane;
    public Vector3 offset;

    void Start()
    {

    }

    void Update()
    {
      Vector3 desiredPosition = new Vector3(transform.position.x, plane.transform.position.y + offset.y, plane.transform.position.z + offset.z);
      transform.position = desiredPosition;
    }
  }
}