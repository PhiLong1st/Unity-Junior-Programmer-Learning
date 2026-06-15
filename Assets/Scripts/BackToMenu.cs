using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
  private const string menuSceneName = "Main Menu";
  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      SceneManager.LoadScene(menuSceneName);
    }
  }
}