using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class ObjectDialog : MonoBehaviour
{
    [SerializeField]
    internal List<Dialog> m_messages;

    public void TestUnityEvent()
    {
        Debug.Log("TEST");
    }
}

[System.Serializable]
public class Dialog
{
    public bool m_isQuestion;
    public bool m_isDialogEnder;
    public string m_message;
    public int m_yesMessageIndex;
    public int m_noMessageIndex;

    public UnityEvent m_preMessageActions;
    public UnityEvent m_postMessageActions;
}
