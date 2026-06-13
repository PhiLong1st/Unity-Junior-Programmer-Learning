using UnityEngine;

namespace Challenge5
{
  public class FoodView : MonoBehaviour
  {
    private Food _model;
    private GameObject _explosionFx;

    public void Initialize(FoodData data, Food model)
    {
      _model = model;
      _explosionFx = data.explosionFx;
    }

    public void ShowExplosionEffect()
    {
      if (_explosionFx != null)
      {
        Debug.LogWarning("Explosion FX is null. Cannot show explosion.");
        return;
      }

      Instantiate(_explosionFx, transform.position, Quaternion.identity);
    }

    public void ShowTimingEffect()
    {
      if (_model != null)
      {
        Debug.LogWarning("Model is null. Cannot show timing effect.");
        return;
      }

      // TODO: Implement timing effect  based on _model.RemainingTimePercentage
    }
  }
}