using UnityEngine;

public class Garbage : MonoBehaviour
{
    public GarbageType m_garbageType;

    internal bool m_isOnConveyor;
    internal bool m_isDragging;
    internal bool m_isInBin;
    internal bool m_isInCorrectBin;

    void Start()
    {
        m_isOnConveyor = true;
        m_isDragging = false;
    }

    void OnMouseDown()
    {
        m_isDragging = true;

    }

    void OnMouseDrag()
    {
        Vector2 dragPos = new Vector2();
        Vector2 touchPos = new Vector2();
        if (SystemInfo.deviceType == DeviceType.Handheld)
            touchPos = Input.GetTouch(0).position;
        else
            touchPos = Input.mousePosition;

        dragPos = FindObjectOfType<Camera>().ScreenToWorldPoint(touchPos);
        transform.position = dragPos;
    }

    void OnMouseUp()
    {
        m_isDragging = false;
        if (!m_isOnConveyor || m_isInBin)
        {
            DestroyGarbage();
        }
    }

    internal void DestroyGarbage()
    {
        if (!m_isOnConveyor && !m_isInBin)
        {
            Debug.Log("Missed");
        }
        else if (m_isInBin)
        {
            if (m_isInCorrectBin)
            {
                Debug.Log("Correct");
            }
            else
            {
                Debug.Log("Wrong");
            }
        }
        Destroy(gameObject);
    }
}

public enum GarbageType
{
    Biodegradable,
    NonBiodegradable
}
