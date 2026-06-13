namespace Challenge5
{
  using UnityEngine;
  using UnityEngine.UI;

  public class DifficultyButtonX : MonoBehaviour
  {
    private Button _button;
    public int difficulty;

    void Start()
    {
      _button = GetComponent<Button>();
      _button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
      Debug.Log(_button.gameObject.name + " was clicked");
      GameManager.Instance.StartGame();
    }
  }
}