using UnityEngine;
public enum CarbonBlockType
{
    Downward,
    Upward
}

public class CarbonBlock : MonoBehaviour
{
    internal float m_speed;
    internal CarbonBlockType m_carbonBlockType;
    internal int m_position;

    private OzoneSpawner m_spawner;

    void Start()
    {
        if (m_carbonBlockType == CarbonBlockType.Upward)
        {
            m_spawner = FindObjectOfType<OzoneSpawner>();
        }
    }

    void Update()
    {
        float speed = 0;
        if (m_carbonBlockType == CarbonBlockType.Downward)
        {
            speed = -m_speed;
        }
            
        else
        {
            speed = m_speed;

            if (m_spawner.m_carbonBlockRows.Count > 0)
            {
                for (int carbonBlockRowIndex = 0; carbonBlockRowIndex < m_spawner.m_carbonBlockRows.Count; carbonBlockRowIndex++)
                {
                    CarbonBlockRow carbonBlockRow = m_spawner.m_carbonBlockRows[carbonBlockRowIndex];

                    bool blankFound = false;
                    foreach (int blank in carbonBlockRow.m_blanks)
                    {
                        if (blank == m_position)
                        {
                            blankFound = true;
                            break;
                        }
                    }

                    if (blankFound)
                    {
                        if (Vector3.Distance(transform.position, new Vector3(transform.position.x, carbonBlockRow.m_currentYPos, transform.position.z)) <= 2 * m_speed * Time.deltaTime)
                        {
                            carbonBlockRow.AddBlock(this, m_position);
                        }
                        break;
                    }
                }
            }
        }
            

        GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + new Vector2(0, speed * Time.deltaTime));
    }
}
