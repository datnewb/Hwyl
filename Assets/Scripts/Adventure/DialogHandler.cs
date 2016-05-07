using UnityEngine;
using System.Collections;

public class DialogHandler : MonoBehaviour
{
    [SerializeField]
    internal GameObject m_dialogPanel;
    [SerializeField]
    internal GameObject m_dialogNamePanel;

    private bool m_canGoNext = false;
    internal bool m_isInDialog = false;

    private Interactible m_objectInteracting = null;
    private PlayerMovement m_playerMovement = null;

    void Start()
    {
        m_dialogPanel.SetActive(false);
        m_playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (m_canGoNext)
        {
            if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
            {
                EndDialog();
            }
        }
    }

    internal void StartDialog(Interactible interactible)
    {
        m_playerMovement.m_canMove = false;

        m_dialogPanel.SetActive(true);
        if (interactible.m_interactibleType == InteractibleType.Object)
            m_dialogNamePanel.SetActive(false);
        else
            m_dialogNamePanel.SetActive(true);
        m_isInDialog = true;
        m_objectInteracting = interactible;
        m_canGoNext = true;
    }

    internal void EndDialog()
    {
        m_dialogPanel.SetActive(false);
        m_canGoNext = false;
        Invoke("DialogReset", 0.1f);
    }

    private void DialogReset()
    {
        m_playerMovement.m_canMove = true;

        m_objectInteracting.m_isInteracting = false;
        m_isInDialog = false;
    }

    private void AllowNext()
    {
        m_canGoNext = true;
    }
}
