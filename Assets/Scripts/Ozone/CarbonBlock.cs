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

    void Update()
    {
        float speed = 0;
        if (m_carbonBlockType == CarbonBlockType.Downward)
            speed = -m_speed;
        else
            speed = m_speed;

        GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + new Vector2(0, speed * Time.deltaTime));
    }
}
