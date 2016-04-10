using UnityEngine;

public class ConveyorEnd : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D p_other)
    {
        Garbage garbage = p_other.GetComponent<Garbage>();
        if (garbage != null)
            garbage.DestroyGarbage();
    }
}
