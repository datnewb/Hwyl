using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(Camera.main.transform.position, Vector3.up);
    }
}
