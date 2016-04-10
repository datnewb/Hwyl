using UnityEngine;
using System.Collections.Generic;

public class GarbageSpawner : MonoBehaviour
{
    private float m_maxSpawnTimeInterval = 5;
    private float m_minSpawnTimeInterval = 2;
    //randomized time between m_minSpawnTimeInterval and m_maxSpawnTimeInterval
    private float m_nextSpawnTime;
    private float m_curSpawnTime;

    [SerializeField]
    private List<GameObject> m_garbages;

    private Rect m_spawnArea;

    private bool m_canSpawn;

    void Start()
    {
        Bounds box = GetComponent<BoxCollider2D>().bounds;
        m_spawnArea = new Rect(
            box.min.x,
            box.min.y,
            box.size.x,
            box.size.y);

        m_curSpawnTime = 0;
        m_nextSpawnTime = 0;
        m_canSpawn = true;
    }

    void Update()
    {
        if (m_canSpawn)
        {
            m_curSpawnTime += Time.deltaTime;
            if (m_curSpawnTime >= m_nextSpawnTime)
            {
                Spawn();
                ResetTimer();
            }
        }
    }

    void Spawn()
    {
        GameObject garbageToSpawn = m_garbages[Random.Range(0, m_garbages.Count)];
        Vector3 randomSpawnPosition = new Vector3(Random.Range(m_spawnArea.xMin, m_spawnArea.xMax), Random.Range(m_spawnArea.yMin, m_spawnArea.yMax));

        Instantiate(garbageToSpawn, randomSpawnPosition, Quaternion.identity);
    }

    void ResetTimer()
    {
        m_curSpawnTime = 0;
        m_nextSpawnTime = Random.Range(m_minSpawnTimeInterval, m_maxSpawnTimeInterval);
    }
}
