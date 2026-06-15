using UnityEngine;
using UnityEngine.UI;
namespace Challenge5
{
  public enum LevelDifficulty
  {
    Easy,
    Medium,
    Hard
  }

  public class DifficultyButtonX : MonoBehaviour
  {
    [SerializeField] private LevelData data;

    private Button button;

    private void Awake()
    {
      button = GetComponent<Button>();
    }

    private void OnEnable()
    {
      button.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
      GameManagerX.Instance.StartGame(data);
    }

    private void OnDisable()
    {
      button.onClick.RemoveListener(SetDifficulty);
    }
  }
}
