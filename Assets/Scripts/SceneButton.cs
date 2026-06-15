using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
  [SerializeField] private string sceneName;
  private TextMeshPro textMeshPro;

  private void Awake()
  {
    textMeshPro = GetComponent<TextMeshPro>();
  }

  private void Start()
  {
    textMeshPro.text = sceneName;
  }

  private void OnMouseDown()
  {
    LoadScene(sceneName);
  }

  private void LoadScene(string sceneName)
  {
    SceneManager.LoadScene(sceneName);
  }
}
