namespace Challenge5
{
  using UnityEngine;

  public class AutoDestroy : MonoBehaviour
  {
    [SerializeField] private float destroyDelay = 2f;

    private void Start()
    {
      Destroy(gameObject, destroyDelay);
    }
  }
}
