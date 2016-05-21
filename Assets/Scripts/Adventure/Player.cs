using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Player Start");
    }

    void Update()
    {
        if (SceneLoader.GetPreviousSceneName() != SceneManager.GetActiveScene().name)
        {
            Debug.Log("Found Start");
            PlayerStart playerStart = FindObjectOfType<PlayerStartManager>().GetPlayerStart(SceneLoader.ConvertSceneStringToEnum(SceneLoader.GetPreviousSceneName()));
            transform.position = playerStart.transform.position;
        }

        Destroy(this);
    }
}
