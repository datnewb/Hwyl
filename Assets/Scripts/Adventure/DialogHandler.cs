using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogHandler : MonoBehaviour
{
    [SerializeField]
    internal GameObject m_dialogPanel;
    [SerializeField]
    internal Text m_dialogName;
    [SerializeField]
    internal Text m_dialogMessage;
    [SerializeField]
    internal GameObject m_dialogNamePanel;
    [SerializeField]
    internal GameObject m_dialogAnswerPanel;

    private bool m_canGoNext = false;
    private bool m_isQuestion = false;
    internal bool m_isInDialog = false;

    private Interactible m_objectInteracting = null;
    private int m_currentDialogCount = -1;
    private int m_previousDialogCount = -1;
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
            if (!m_isQuestion)
            {
                if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
                {
                    if (m_currentDialogCount + 1 < m_objectInteracting.m_objectDialog.m_messages.Count &&
                        !m_objectInteracting.m_objectDialog.m_messages[m_currentDialogCount].m_isDialogEnder)
                    {
                        NextDialogMessage();
                    }
                    else
                    {
                        EndDialog();
                    }
                }
            }
        }
    }

    internal void StartDialog(Interactible interactible)
    {
        m_playerMovement.m_canMove = false;

        m_dialogPanel.SetActive(true);
        if (interactible.m_interactibleType == InteractibleType.Object)
        {
            m_dialogNamePanel.SetActive(false);
        }
        else
        {
            m_dialogNamePanel.SetActive(true);
            m_dialogName.text = interactible.m_name;
        }

        m_isInDialog = true;
        m_objectInteracting = interactible;
        m_canGoNext = true;

        m_previousDialogCount = -1;
        NextDialogMessage(0);
    }

    internal void NextDialogMessage()
    {
        m_previousDialogCount = m_currentDialogCount;
        m_currentDialogCount++;

        Dialog currentDialog = m_objectInteracting.m_objectDialog.m_messages[m_currentDialogCount];
        Dialog previousDialog = null;
        if (m_previousDialogCount != -1)
            previousDialog = m_objectInteracting.m_objectDialog.m_messages[m_previousDialogCount];

        if (previousDialog != null && previousDialog.m_postMessageActions != null)
        {
            previousDialog.m_postMessageActions.Invoke();
        }

        if (currentDialog.m_preMessageActions != null)
        {
            currentDialog.m_preMessageActions.Invoke();
        }

        m_canGoNext = false;
        Invoke("AllowNext", 0.1f);

        
        m_dialogMessage.text = currentDialog.m_message;
        m_isQuestion = currentDialog.m_isQuestion;
        if (m_isQuestion)
            ShowAnswerPanel();
        else
            HideAnswerPanel();
    }

    internal void NextDialogMessage(int index)
    {
        m_currentDialogCount = index;
        m_previousDialogCount = m_currentDialogCount;

        Dialog currentDialog = m_objectInteracting.m_objectDialog.m_messages[m_currentDialogCount];
        Dialog previousDialog = null;
        if (m_previousDialogCount != -1)
            previousDialog = m_objectInteracting.m_objectDialog.m_messages[m_previousDialogCount];

        if (previousDialog != null && previousDialog.m_postMessageActions != null)
        {
            previousDialog.m_postMessageActions.Invoke();
        }

        if (currentDialog.m_preMessageActions != null)
        {
            currentDialog.m_preMessageActions.Invoke();
        }

        m_canGoNext = false;
        Invoke("AllowNext", 0.1f);

        m_dialogMessage.text = m_objectInteracting.m_objectDialog.m_messages[m_currentDialogCount].m_message;
        m_isQuestion = m_objectInteracting.m_objectDialog.m_messages[m_currentDialogCount].m_isQuestion;
        if (m_isQuestion)
            ShowAnswerPanel();
        else
            HideAnswerPanel();
    }

    internal void ShowAnswerPanel()
    {
        m_dialogAnswerPanel.SetActive(true);
    }

    internal void HideAnswerPanel()
    {
        m_dialogAnswerPanel.SetActive(false);
    }

    public void YesAnswer()
    {
        NextDialogMessage(m_objectInteracting.m_objectDialog.m_messages[m_currentDialogCount].m_yesMessageIndex);
        HideAnswerPanel();
    }

    public void NoAnswer()
    {
        NextDialogMessage(m_objectInteracting.m_objectDialog.m_messages[m_currentDialogCount].m_noMessageIndex);
        HideAnswerPanel();
    }

    internal void EndDialog()
    {
        m_dialogPanel.SetActive(false);
        m_canGoNext = false;
        m_currentDialogCount = 0;
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
