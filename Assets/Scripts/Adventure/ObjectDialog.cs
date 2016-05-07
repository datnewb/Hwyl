using UnityEngine;
using System.Collections.Generic;

public class ObjectDialog : MonoBehaviour
{
    [SerializeField]
    internal List<Dialog> m_messages;
}

[System.Serializable]
public class Dialog
{
    public bool m_isQuestion;
    public bool m_isDialogEnder;
    public string m_message;
    public int m_yesMessageIndex;
    public int m_noMessageIndex;
}
