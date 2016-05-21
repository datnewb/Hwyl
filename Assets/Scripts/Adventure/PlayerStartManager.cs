using UnityEngine;
using System.Collections.Generic;

public class PlayerStartManager : MonoBehaviour
{
    internal List<PlayerStart> m_playerStartPoints;

    void Start()
    {
        Debug.Log("Initialized player start manager");
        m_playerStartPoints = new List<PlayerStart>();
        foreach (PlayerStart playerStart in FindObjectsOfType<PlayerStart>())
        {
            m_playerStartPoints.Add(playerStart);
        }
        Debug.Log(m_playerStartPoints.Count);
    }

    public PlayerStart GetPlayerStart(SceneEnum p_previousScene)
    {
        Debug.Log(m_playerStartPoints.Count);
        foreach (PlayerStart playerStart in m_playerStartPoints)
        {
            if (playerStart.m_previousScene == p_previousScene)
            {
                return playerStart;
            }
        }

        return null;
    }
}
