using UnityEngine;
using System.Collections.Generic;

public class CarbonBlockRow
{
    internal List<CarbonBlock> m_carbonBlocks;
    internal List<int> m_blanks;

    internal float m_currentYPos;

    public CarbonBlockRow(List<CarbonBlock> p_carbonBlocks, List<int> p_blanks)
    {
        m_carbonBlocks = p_carbonBlocks;
        m_blanks = p_blanks;

        m_currentYPos = m_carbonBlocks[0].transform.position.y;
    }

    internal void UpdateYPos()
    {
        m_currentYPos = m_carbonBlocks[0].transform.position.y;
    }

    internal bool IsRowFull()
    {
        if (m_blanks.Count <= 0)
            return true;

        return false;
    }

    internal void AddBlock(CarbonBlock p_carbonBlock, int p_position)
    {
        m_carbonBlocks.Add(p_carbonBlock);
        if (m_carbonBlocks.Count >= 4)
        {
            Object.FindObjectOfType<CarbonBlockDestroyer>().DestroyRow(p_carbonBlock.gameObject);
        }
        else
        {
            CarbonBlock addedBlock = m_carbonBlocks[m_carbonBlocks.IndexOf(p_carbonBlock)];
            addedBlock.m_carbonBlockType = CarbonBlockType.Downward;
            m_blanks.Remove(p_position);
        }
    }
}
