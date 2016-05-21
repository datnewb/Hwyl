using UnityEngine;
using System.Collections;

public class CarbonBlockDestroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        CarbonBlock carbonBlock = other.transform.root.GetComponent<CarbonBlock>();
        if (carbonBlock != null)
        {
            if (carbonBlock.m_carbonBlockType == CarbonBlockType.Downward)
            {
                BottomReached(carbonBlock.gameObject);
            }
        }
    }

    private void BottomReached(GameObject p_carbonBlockObject)
    {
        Destroy(p_carbonBlockObject);
    }
}
