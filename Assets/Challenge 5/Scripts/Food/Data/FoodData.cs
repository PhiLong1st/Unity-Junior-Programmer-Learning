using UnityEngine;

namespace Challenge5
{
  [CreateAssetMenu(fileName = "FoodData", menuName = "Challenge 5/FoodData", order = 0)]
  public class FoodData : ScriptableObject
  {
    public string foodName;
    public FoodType foodType;
    public float timeOnScreen;
    public int pointValue;
    public GameObject explosionFx;
  }
}