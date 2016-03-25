using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
