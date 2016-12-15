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
	public float GetRatioToGap(SHUIWidge_Stick pStick, SHUIWidge_Monster pMonster)
	{
		if ((null == pStick) || (null == pMonster))
			return 0.0f;

		var fRatio = Mathf.Abs(pMonster.GetLocalPosition().x - pStick.GetLocalPosition().x) / 150.0f;//pMonster.GetCollider().bounds.size.x;
		return Mathf.Clamp(fRatio, 0.0f, 1.0f);
	}
    public eDecision GetDecision(SHUIWidge_Stick pStick, SHUIWidge_Monster pMonster)
    {
        if ((null == pStick) || (null == pMonster))
            return eDecision.Miss;

        var fGap = Mathf.Abs(pMonster.GetLocalPosition().x - pStick.GetLocalPosition().x);
        var fSep = 50.0f;//pMonster.GetCollider().bounds.size.x / 3.0f;

        if (fGap <= (fSep * 0.5f)) return eDecision.Good;
        if (fGap <= (fSep * 1.5f)) return eDecision.Normal;
        if (fGap <= (fSep * 3.0f)) return eDecision.Bad;

        return eDecision.Miss;
    }
    public eMonsterType GetMonsterType()
    {
        return SHMath.RandomN(Single.Inventory.GetEnableMonsters());
    }
    public float GetMonsterSpeed()
    {
        var iLevel  = (int)(Single.ScoreBoard.m_iScore / 10.0f);
        var pWeight = new List<float>();
        switch (iLevel)
        {
            case 0:  pWeight = new List<float>() { 1.00f, 0.90f, 0.30f, 0.10f, 0.00f, 0.00f };   break;
            case 1:  pWeight = new List<float>() { 0.90f, 0.80f, 0.40f, 0.20f, 0.10f, 0.00f };   break;
            case 2:  pWeight = new List<float>() { 0.80f, 0.70f, 0.40f, 0.30f, 0.20f, 0.10f };   break;
            case 3:  pWeight = new List<float>() { 0.70f, 0.60f, 0.40f, 0.40f, 0.30f, 0.20f };   break;
            case 4:  pWeight = new List<float>() { 0.60f, 0.50f, 0.40f, 0.40f, 0.30f, 0.30f };   break;
            case 5:  pWeight = new List<float>() { 0.50f, 0.40f, 0.50f, 0.40f, 0.40f, 0.30f };   break;
            case 6:  pWeight = new List<float>() { 0.40f, 0.30f, 0.50f, 0.50f, 0.40f, 0.40f };   break;
            case 7:  pWeight = new List<float>() { 0.30f, 0.20f, 0.50f, 0.50f, 0.40f, 0.40f };   break;
            case 8:  pWeight = new List<float>() { 0.20f, 0.10f, 0.50f, 0.50f, 0.50f, 0.50f };   break;
            case 9:  pWeight = new List<float>() { 0.10f, 0.10f, 0.50f, 0.60f, 0.50f, 0.50f };   break;
            default: pWeight = new List<float>() { 0.10f, 0.10f, 0.60f, 0.60f, 0.50f, 0.70f };   break;
        }
        return SHMath.RandomW(new List<float>()  { 1.00f, 0.90f, 0.80f, 0.70f, 0.60f, 0.50f }, pWeight);
    }
    #endregion


    #region Utility Functions
    #endregion


    #region Event Handler
    #endregion
}
