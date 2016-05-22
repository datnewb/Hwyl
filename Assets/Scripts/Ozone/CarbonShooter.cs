using UnityEngine;

public class CarbonShooter : MonoBehaviour
{
    public int m_position;

    [SerializeField]
    private float m_shootSpeed;

    [SerializeField]
    private GameObject m_carbonBlock;

    [SerializeField]
    private float m_shootCooldown;
    private float m_curShootCooldown = 0;
    private bool m_canShoot = true;

    void Update()
    {
        if (!m_canShoot)
        {
            m_curShootCooldown += Time.deltaTime;
            if (m_curShootCooldown >= m_shootCooldown)
            {
                m_curShootCooldown = 0;
                m_canShoot = true;
            }
        }
    }

    void OnMouseDown()
    {
        if (m_canShoot)
        {
            GameObject carbonBlock = Instantiate(m_carbonBlock, transform.position, Quaternion.identity) as GameObject;
            carbonBlock.GetComponent<CarbonBlock>().m_carbonBlockType = CarbonBlockType.Upward;
            carbonBlock.GetComponent<CarbonBlock>().m_speed = m_shootSpeed;
            carbonBlock.GetComponent<CarbonBlock>().m_position = m_position;

            m_canShoot = false;
        }
        
    }
}
