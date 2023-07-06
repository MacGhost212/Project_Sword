using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "LevelSelector";

    public void Play()
    {
        Debug.Log("Play");
        SceneManager.LoadScene("LevelSelector");
    }

    public void Quit()
    {
        Debug.Log("Exiting....");
        Application.Quit();

    }
}
