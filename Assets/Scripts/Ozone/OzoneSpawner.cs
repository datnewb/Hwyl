using UnityEngine;
using System.Collections.Generic;

public class OzoneSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] m_spawnPoints;
    [SerializeField]
    private GameObject m_carbonBlock;

    [SerializeField]
    internal float m_carbonBlockSpeed;

    private bool m_canSpawn = true;

    internal List<CarbonBlockRow> m_carbonBlockRows;
	
    void Start()
    {
        m_carbonBlockRows = new List<CarbonBlockRow>();

        SpawnCarbonBlockRow(1);
    }

    void Update()
    {
        foreach (CarbonBlockRow carbonBlockRow in m_carbonBlockRows)
        {
            carbonBlockRow.UpdateYPos();
        }

        if (m_carbonBlockRows.Count <= 0)
        {
            SpawnCarbonBlockRow(1);
        }
    }

    private void SpawnCarbonBlockRow(int p_exceptions)
    {
        List<CarbonBlock> carbonBlocks = new List<CarbonBlock>();

        List<int> exceptions = new List<int>();
        for (int i = 0; i < p_exceptions; i++)
            exceptions.Add(Random.Range(0, m_spawnPoints.Length));

        for (int spawnIndex = 0; spawnIndex < m_spawnPoints.Length; spawnIndex++)
        {
            bool exceptionFound = false;
            for (int exceptionIndex = 0; exceptionIndex < exceptions.Count; exceptionIndex++)
            {
                if (spawnIndex == exceptions[exceptionIndex])
                {
                    exceptionFound = true;
                    break;
                }
            }

            if (!exceptionFound)
            {
                carbonBlocks.Add(SpawnCarbonBlock(m_spawnPoints[spawnIndex].position, spawnIndex));
            }
        }

        CarbonBlockRow carbonBlockRow = new CarbonBlockRow(carbonBlocks, exceptions);
        m_carbonBlockRows.Add(carbonBlockRow);
    }

    private CarbonBlock SpawnCarbonBlock(Vector2 p_position, int p_index)
    {
        GameObject carbonBlock = Instantiate(m_carbonBlock, p_position, Quaternion.identity) as GameObject;
        carbonBlock.GetComponent<CarbonBlock>().m_position = p_index;
        carbonBlock.GetComponent<CarbonBlock>().m_speed = m_carbonBlockSpeed;
        carbonBlock.GetComponent<CarbonBlock>().m_carbonBlockType = CarbonBlockType.Downward;

        return carbonBlock.GetComponent<CarbonBlock>();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (m_canSpawn)
        {
            SpawnCarbonBlockRow(1);

            m_canSpawn = false;
            Invoke("ResetSpawn", 0.01f);
        }   
    }

    private void ResetSpawn()
    {
        m_canSpawn = true;
    }
}
