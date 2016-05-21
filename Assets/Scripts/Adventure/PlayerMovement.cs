using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool m_shouldCameraFollow;
    public LayerMask m_interactMask;

    private NavMeshAgent m_navMeshAgent;
    internal bool m_canMove;

    private Vector3 m_cameraDistanceFromPlayer;

    void Start()
    {
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        m_canMove = true;

        m_cameraDistanceFromPlayer = transform.position + Camera.main.transform.position;
    }

    void Update()
    {
        if (m_canMove)
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
        else
        {
            m_navMeshAgent.SetDestination(transform.position);
        }

        if (m_shouldCameraFollow)
        {
            Camera.main.transform.position = m_cameraDistanceFromPlayer + transform.position;
        }
    }
}
