using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Challenge2
{
  public class Ball : MonoBehaviour
  {
    private float bottomLimit = 0;

    void Update()
    {
      if (transform.position.y < bottomLimit)
      {
        Debug.Log("Game Over!");
        Destroy(gameObject);
      }
    }
  }
}