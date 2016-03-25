using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool m_shouldCameraFollow;
    public LayerMask m_interactMask;

    private NavMeshAgent m_navMeshAgent;

    void Start()
    {
        m_navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            Vector2 screenClickPoint = Vector2.zero;
            if (Input.touchCount > 0)
                screenClickPoint = Input.GetTouch(0).position;
            else
                screenClickPoint = Input.mousePosition;
            Ray cameraRay = Camera.main.ScreenPointToRay(new Vector3(screenClickPoint.x, screenClickPoint.y, 0));
            RaycastHit hitInfo;
            if (Physics.Raycast(cameraRay, out hitInfo, 100, m_interactMask))
            {
                m_navMeshAgent.SetDestination(hitInfo.point);
            }
        }
    }
}
