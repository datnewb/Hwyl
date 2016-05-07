using UnityEngine;

public class GarbageBin : MonoBehaviour
{
    public GarbageType m_garbageType;

    void OnTriggerEnter2D(Collider2D p_other)
    {
        Garbage garbage = p_other.GetComponent<Garbage>();
        if (garbage != null)
        {
            garbage.m_isInBin = true;
            if (garbage.m_garbageType == m_garbageType)
            {
                garbage.m_isInCorrectBin = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D p_other)
    {
        Garbage garbage = p_other.GetComponent<Garbage>();
        if (garbage != null)
        {
            garbage.m_isInBin = false;
            garbage.m_isInCorrectBin = false;
        }
    }
}
