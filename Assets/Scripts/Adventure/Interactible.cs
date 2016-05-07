using UnityEngine;

public enum InteractibleType
{
    Person,
    Object
}

public class Interactible : MonoBehaviour
{
    [SerializeField]
    internal InteractibleType m_interactibleType;
    [SerializeField]
    internal string m_name;

    private GameObject m_playerObject;
    internal bool m_isInteracting;

    private DialogHandler m_dialogHandler;

    internal ObjectDialog m_objectDialog;

    void Start()
    {
        m_playerObject = GameObject.FindGameObjectWithTag("Player");
        m_isInteracting = false;

        m_dialogHandler = FindObjectOfType<DialogHandler>();
        m_objectDialog = GetComponent<ObjectDialog>();
    }

    void Update()
    {
        if (m_isInteracting)
        {   
            if (Vector3.Distance(transform.position, m_playerObject.transform.position) < 3)
            {
                if (!m_dialogHandler.m_isInDialog)
                    m_dialogHandler.StartDialog(this);
            }
        }

        //check if this object was clicked/touched
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            Vector2 screenClickPoint = Vector2.zero;
            if (Input.touchCount > 0)
                screenClickPoint = Input.GetTouch(0).position;
            else
                screenClickPoint = Input.mousePosition;
            Ray cameraRay = Camera.main.ScreenPointToRay(new Vector3(screenClickPoint.x, screenClickPoint.y, 0));
            RaycastHit hitInfo;
            if (Physics.Raycast(cameraRay, out hitInfo, 100))
            {
                if (hitInfo.collider.transform.root == transform)
                {
                    m_isInteracting = true;
                }
                else
                {
                    m_isInteracting = false;
                }
            }
        }
    }
}
