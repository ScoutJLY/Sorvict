using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Opening");
    }

    public void QuitGame()
    {
        Debug.Log("This game will now quit.");
        Application.Quit();
    }

    public void RestartMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
