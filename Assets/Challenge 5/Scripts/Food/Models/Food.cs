using UnityEngine;

namespace Challenge5
{

  public class Food
  {
    public FoodType FoodType { get; private set; }
    public float TimeOnScreen { get; private set; }
    public int PointValue { get; private set; }

    private float _remainingTime;

    public float RemainingTime => _remainingTime;

    public float RemainingTimePercentage => _remainingTime / TimeOnScreen;

    public Food(FoodData data)
    {
      FoodType = data.foodType;
      TimeOnScreen = data.timeOnScreen;
      PointValue = data.pointValue;
    }

    public void StartTimer()
    {
      _remainingTime = TimeOnScreen;
    }

    public void UpdateTimer(float deltaTime)
    {
      _remainingTime = Mathf.Max(_remainingTime - deltaTime, 0f);
    }
  }
}