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
	
    void Start()
    {
        List<int> exceptions = new List<int>();
        exceptions.Add(Random.Range(0, m_spawnPoints.Length));
        Debug.Log(exceptions[0]);

        SpawnCarbonBlockColumn(exceptions);
    }

    private void SpawnCarbonBlockColumn(List<int> p_exceptions)
    {
        for (int spawnIndex = 0; spawnIndex < m_spawnPoints.Length; spawnIndex++)
        {
            bool exceptionFound = false;
            for (int exceptionIndex = 0; exceptionIndex < p_exceptions.Count; exceptionIndex++)
            {
                if (spawnIndex == p_exceptions[exceptionIndex])
                {
                    exceptionFound = true;
                    break;
                }
            }

            if (!exceptionFound)
            {
                SpawnCarbonBlock(m_spawnPoints[spawnIndex].position);
            }
        }
    }

    private void SpawnCarbonBlock(Vector2 p_position)
    {
        GameObject carbonBlock = Instantiate(m_carbonBlock, p_position, Quaternion.identity) as GameObject;
        carbonBlock.GetComponent<CarbonBlock>().m_speed = m_carbonBlockSpeed;
        carbonBlock.GetComponent<CarbonBlock>().m_carbonBlockType = CarbonBlockType.Downward;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (m_canSpawn)
        {
            List<int> exceptions = new List<int>();
            exceptions.Add(Random.Range(0, m_spawnPoints.Length));
            Debug.Log(exceptions[0]);

            SpawnCarbonBlockColumn(exceptions);

            m_canSpawn = false;
            Invoke("ResetSpawn", 0.01f);
        }   
    }

    private void ResetSpawn()
    {
        m_canSpawn = true;
    }
}
