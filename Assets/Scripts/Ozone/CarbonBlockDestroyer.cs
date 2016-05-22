using UnityEngine;

public class CarbonBlockDestroyer : MonoBehaviour
{
    [SerializeField]
    private CarbonBlockType m_carbonBlockType;

    void OnTriggerEnter2D(Collider2D other)
    {
        CarbonBlock carbonBlock = other.transform.root.GetComponent<CarbonBlock>();
        if (carbonBlock != null)
        {
            if (carbonBlock.m_carbonBlockType == m_carbonBlockType)
            {
                if (m_carbonBlockType == CarbonBlockType.Downward)
                    BottomReached(carbonBlock.gameObject);
                else
                    TopReached(carbonBlock.gameObject);
            }
        }
    }

    private void BottomReached(GameObject p_carbonBlockObject)
    {
        DestroyRow(p_carbonBlockObject);
    }

    internal void DestroyRow(GameObject p_carbonBlockObject)
    {
        OzoneSpawner spawner = FindObjectOfType<OzoneSpawner>();
        CarbonBlockRow carbonBlockRow = null;
        foreach (CarbonBlockRow carbonRow in spawner.m_carbonBlockRows)
        {
            if (carbonRow.m_carbonBlocks.Contains(p_carbonBlockObject.GetComponent<CarbonBlock>()))
            {
                carbonBlockRow = carbonRow;
                foreach (CarbonBlock carbonBlock in carbonRow.m_carbonBlocks)
                {
                    Destroy(carbonBlock.transform.root.gameObject);
                }
                break;
            }
        }

        if (carbonBlockRow != null)
        {
            spawner.m_carbonBlockRows.Remove(carbonBlockRow);
        }
    }

    private void TopReached(GameObject p_carbonBlockObject)
    {
        Destroy(p_carbonBlockObject);
    }
}
