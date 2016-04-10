using UnityEngine;

public class Garbage : MonoBehaviour
{
    internal bool m_isOnConveyor;
    internal bool m_isDragging;

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
        if (!m_isOnConveyor)
        {
            DestroyGarbage();
        }
    }

    internal void DestroyGarbage()
    {
        Destroy(gameObject);
    }
}
