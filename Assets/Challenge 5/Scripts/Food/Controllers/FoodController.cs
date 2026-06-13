using UnityEngine;

namespace Challenge5
{
  [RequireComponent(typeof(FoodView))]
  public class FoodController : MonoBehaviour
  {
    [SerializeField] private FoodData data;

    public FoodType Type => _model.FoodType;

    private Food _model;
    private FoodView _view;

    public void Explode()
    {
      _view.ShowExplosionEffect();
      Destroy(gameObject);

      GameManager.Instance.UpdateScore(_model.PointValue);
    }

    private void Awake()
    {
      if (data == null)
      {
        Debug.LogError("FoodData is not assigned in the inspector.");
      }

      _model = new(data);

      _view = GetComponent<FoodView>();
      _view.Initialize(data, _model);
    }

    private void Update()
    {
      if (GameManager.Instance.IsPausing)
      {
        return;
      }

      _model.UpdateTimer(Time.deltaTime);
      _view.ShowTimingEffect();

      if (_model.RemainingTime <= 0f)
      {
        Destroy(gameObject);
        // TODO: Handle food expiration by disable with pool
      }
    }

    private void OnMouseEnter()
    {
      if (GameManager.Instance.IsPausing)
      {
        return;
      }

      Explode();
    }

    private void OnTriggerEnter(Collider other)
    {
      Destroy(gameObject);

      bool isBadFood = _model.FoodType == FoodType.Bad;
      bool collidedWithSensor = other.gameObject.CompareTag(GameTag.Sensor);
      if (collidedWithSensor && isBadFood)
      {
        GameManager.Instance.EndGame();
      }
    }
  }
}