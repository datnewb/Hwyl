using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [SerializeField]
    private float m_startSpeed;
    private float m_speed;

    void Start()
    {
        m_speed = m_startSpeed;
    }

    void OnTriggerStay2D(Collider2D p_other)
    {
        Garbage garbage = p_other.GetComponent<Garbage>();
        if (garbage != null)
        {
            if (!garbage.m_isDragging)
            {
                Vector2 velocity = new Vector2(-m_speed, 0) * Time.deltaTime;
                p_other.GetComponent<Rigidbody2D>().MovePosition((Vector2)p_other.transform.position + velocity);
            }
            
            garbage.m_isOnConveyor = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D p_other)
    {
        Garbage garbage = p_other.GetComponent<Garbage>();
        if (garbage != null)
        {
            garbage.m_isOnConveyor = false;
        }
    }
}
