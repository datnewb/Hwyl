using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static string g_previousSceneKey = "previousScene";

    public void GoToTestRoom01()
    {
        SetPreviousSceneName(GetCurrentSceneEnum().ToString());
        SceneManager.LoadScene("TestRoom01");
    }

    public void GoToTestRoom02()
    {
        SetPreviousSceneName(GetCurrentSceneEnum().ToString());
        SceneManager.LoadScene("TestRoom02");
    }

    public static SceneEnum GetCurrentSceneEnum()
    {
        return ConvertSceneStringToEnum(SceneManager.GetActiveScene().name);
    }

    public static SceneEnum ConvertSceneStringToEnum(string p_sceneName)
    {
        SceneEnum currentScene = SceneEnum.None;

        switch (p_sceneName)
        {
            case "TestRoom01":
                currentScene = SceneEnum.TestRoom01;
                break;
            case "TestRoom02":
                currentScene = SceneEnum.TestRoom02;
                break;
        }

        return currentScene;
    }

    public static void SetPreviousSceneName(string p_previousSceneName)
    {
        PlayerPrefs.SetString(g_previousSceneKey, p_previousSceneName);
    }

    public static string GetPreviousSceneName()
    {
        return PlayerPrefs.GetString(g_previousSceneKey);
    }
}

public enum SceneEnum
{
    None,
    TestRoom01,
    TestRoom02
}
