using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SHBalance : SHBaseEngine
{
    #region Members
    #endregion


    #region System Functions
    #endregion


    #region Interface Functions
    public eDirection GetDirection(SHUIWidge_Stick pStick, SHUIWidge_Monster pMonster)
    {
        if ((null != pStick) && (null != pMonster))
        {
            if (pMonster.GetLocalPosition().x < pStick.GetLocalPosition().x)
                return eDirection.Left;

            if (pMonster.GetLocalPosition().x > pStick.GetLocalPosition().x)
                return eDirection.Right;
        }

        return SHMath.RandomN(new List<eDirection>()
        {
            eDirection.Left,
            eDirection.Right,
        });
    }
    public eDecision GetDecision(SHUIWidge_Stick pStick, SHUIWidge_Monster pMonster)
    {
        if ((null == pStick) || (null == pMonster))
            return eDecision.Miss;

        var fGap = Mathf.Abs(pMonster.GetLocalPosition().x - pStick.GetLocalPosition().x);
        var fSep = pMonster.GetCollider().size.x / 3.0f;

        if (fGap <= (fSep * 1.0f)) return eDecision.Good;
        if (fGap <= (fSep * 2.0f)) return eDecision.Normal;
        if (fGap <= (fSep * 3.0f)) return eDecision.Bad;

        return eDecision.Miss;
    }
    #endregion


    #region Utility Functions
    #endregion


    #region Event Handler
    #endregion
}
