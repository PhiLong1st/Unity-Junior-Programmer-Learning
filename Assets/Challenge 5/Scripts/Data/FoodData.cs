using UnityEngine;

namespace Challenge5
{
  public enum FoodType
  {
    Cookie,
    Pizza,
    Skull,
    Steak,
  }

  [CreateAssetMenu(fileName = "FoodData", menuName = "Challenge 5/FoodData", order = 0)]
  public class FoodData : ScriptableObject
  {
    public FoodType foodType;
    public int pointValue;
    public GameObject explosionFx;
    public float timeOnScreen = 1.5f;
  }
}