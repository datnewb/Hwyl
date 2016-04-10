using UnityEngine;

public class ConveyorEnd : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D p_other)
    {
        Destroy(p_other.gameObject);
    }
}
