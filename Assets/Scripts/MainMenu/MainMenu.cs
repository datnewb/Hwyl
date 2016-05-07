using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("TestRoom01");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
