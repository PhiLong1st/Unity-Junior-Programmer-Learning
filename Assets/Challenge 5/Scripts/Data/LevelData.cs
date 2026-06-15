using UnityEngine;

namespace Challenge5
{
  [CreateAssetMenu(fileName = "LevelData", menuName = "Challenge 5/LevelData", order = 0)]
  public class LevelData : ScriptableObject
  {
    public LevelDifficulty difficulty;
    public float spawnRate;
  }
}