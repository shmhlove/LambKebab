using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class SHUIWidge_Monster_Info
{
    public float   m_fSpeed       = 1.0f;
    public Vector3 m_vDieSpeed    = Vector3.zero;
    public int     m_iHP          = 1;
    public int     m_iBadScore    = 1;
    public int     m_iNormalScore = 2;
    public int     m_iGoodScore   = 3;

    public void Copy(SHUIWidge_Monster_Info pInfo)
    {
        m_fSpeed       = pInfo.m_fSpeed;
        m_vDieSpeed    = pInfo.m_vDieSpeed;
        m_iHP          = pInfo.m_iHP;
        m_iBadScore    = pInfo.m_iBadScore;
        m_iNormalScore = pInfo.m_iNormalScore;
        m_iGoodScore   = pInfo.m_iGoodScore;
    }
}

public class SHUIWidge_Monster : SHMonoWrapper
{
    public enum eState
    {
        Idle,
        Crash,
        Die,
    }

    #region Members : Inspector
    [SerializeField]
    public SHUIWidge_Monster_Info m_pOriginalInfo = new SHUIWidge_Monster_Info();
    public BoxCollider            m_pCollider    = null;
    public TweenPosition          m_pTweenMove   = null;
    public AnimationClip          m_pDie_Left    = null;
    public AnimationClip          m_pDie_Right   = null;
    #endregion


    #region Members : Info
    private eState                 m_eState      = eState.Idle;
    private SHUIWidge_Monster_Info m_pInfo       = new SHUIWidge_Monster_Info();
    #endregion


    #region Virtual Functions
    public override void FixedUpdate()
    {
        switch (m_eState)
        {
            case eState.Idle:   OnUpdateToIdle();  break;
            case eState.Crash:  OnUpdateToCrash(); break;
            case eState.Die:    OnUpdateToDie();   break;
        }
    }
    void ChangeState(eState _eState, params object[] pArgs)
    {
        switch ((m_eState = _eState))
        {
            case eState.Idle:   OnChangeToIdle(pArgs);  break;
            case eState.Crash:  OnChangeToCrash(pArgs); break;
            case eState.Die:    OnChangeToDie(pArgs);   break;
        }
    }
    private void OnChangeToIdle(params object[] pArgs)
    {
        m_pInfo.Copy(m_pOriginalInfo);

        if (null == m_pTweenMove)
            return;
        
        m_pTweenMove.tweenFactor = (float)pArgs[0];
        m_pTweenMove.duration    = (float)pArgs[1];
        m_pTweenMove.from.y      = ((float)pArgs[2]);
        m_pTweenMove.to.y        = ((float)pArgs[2]);
    }
    private void OnUpdateToIdle()
    {
    }
    private void OnChangeToCrash(params object[] pArgs)
    {
        InitPhysics();
        StopMoveTween();
    }
    private void OnUpdateToCrash()
    {
    }
    private void OnChangeToDie(params object[] pArgs)
    {
        InitPhysics();
        StopMoveTween();

        var eCrashDir = Single.Balance.GetDirection((SHUIWidge_Stick)pArgs[0], this);
        PlayAnim(eDirection.Front, gameObject, (eDirection.Left == eCrashDir) ?
                                                m_pDie_Left : m_pDie_Right, null);

        m_vSpeed = m_pInfo.m_vDieSpeed;
        m_vSpeed.x = (eDirection.Left == eCrashDir) ? -m_vSpeed.x : m_vSpeed.x;
        m_vSpeed.x *= SHMath.Random(0.0f, 2.0f);
    }
    private void OnUpdateToDie()
    {
        SetLocalPosition(
            SHPhysics.CalculationEuler(
                SHPhysics.m_vGravity * 500.0f, GetLocalPosition(), ref m_vSpeed, 1.0f));

        SetLocalScale(GetLocalScale() * 0.99f);

        if (-1000.0f > GetLocalPosition().y)
            SetActive(false);
    }
    #endregion


    #region Interface Functions
    public void Initialize(float fFactor, float fSpeed, float fStartPosY)
    {
        ChangeState(eState.Idle, fFactor, fSpeed, fStartPosY);
    }
    [FuncButton] public void PlayMoveTween()
    {
        if (null == m_pTweenMove)
            return;

        m_pTweenMove.enabled = true;
    }
    [FuncButton] public void StopMoveTween()
    {
        if (null == m_pTweenMove)
            return;

        m_pTweenMove.enabled = false;
    }
    public void SetCrash(SHUIWidge_Stick pStick)
    {
        if (0 == (--m_pInfo.m_iHP))
            ChangeState(eState.Die, pStick);
        else
            ChangeState(eState.Crash);
    }
    public bool IsDie()
    {
        return (eState.Die == m_eState);
    }
    public int GetScore(eDecision eDec)
    {
        switch (eDec)
        {
            case eDecision.Bad:     return m_pInfo.m_iBadScore;
            case eDecision.Normal:  return m_pInfo.m_iNormalScore;
            case eDecision.Good:    return m_pInfo.m_iGoodScore;
        }

        return 0;
    }
    public BoxCollider GetCollider()
    {
        return m_pCollider;
    }
    #endregion


    #region Utility Functions
    #endregion


    #region Event Handler
    #endregion
}
