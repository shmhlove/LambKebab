using UnityEngine;
using System;
using System.Collections;

public class SHGameEngine : SHSingleton<SHGameEngine>
{
    #region Members
    private SHGameStep   m_pGameStep   = new SHGameStep();
    private SHScoreBoard m_pScoreBoard = new SHScoreBoard();
    private SHBalance    m_pBalance    = new SHBalance();
    private SHPlayer     m_pPlayer     = new SHPlayer();
    private SHMonster    m_pMonster    = new SHMonster();
    #endregion


    #region Virtual Functions
    public override void OnInitialize() { }
    public override void OnFinalize()
    {
        if (null != m_pGameStep)
            m_pGameStep.OnFinalize();

        if (null != m_pScoreBoard)
            m_pScoreBoard.OnFinalize();

        if (null != m_pBalance)
            m_pBalance.OnFinalize();
        
        if (null != m_pPlayer)
            m_pPlayer.OnFinalize();

        if (null != m_pMonster)
            m_pMonster.OnFinalize();
    }
    #endregion


    #region System Functions
    #endregion


    #region Interface : System
    public void StartEngine()
    {
        if (null != m_pGameStep)
            m_pGameStep.OnInitialize();

        if (null != m_pScoreBoard)
            m_pScoreBoard.OnInitialize();

        if (null != m_pBalance)
            m_pBalance.OnInitialize();

        if (null != m_pPlayer)
            m_pPlayer.OnInitialize();

        if (null != m_pMonster)
            m_pMonster.OnInitialize();
    }
    public void FrameMove()
    {
        if (null != m_pGameStep)
            m_pGameStep.OnFrameMove();

        if (null != m_pScoreBoard)
            m_pScoreBoard.OnFrameMove();

        if (null != m_pBalance)
            m_pBalance.OnFrameMove();

        if (null != m_pPlayer)
            m_pPlayer.OnFrameMove();

        if (null != m_pMonster)
            m_pMonster.OnFrameMove();
    }
    #endregion


    #region Interface : Helpper
    public SHGameStep GetGameStep()
    {
        return m_pGameStep;
    }
    public SHScoreBoard GetScoreBoard()
    {
        return m_pScoreBoard;
    }
    public SHBalance GetBalance()
    {
        return m_pBalance;
    }
    public SHPlayer GetPlayer()
    {
        return m_pPlayer;
    }
    public SHMonster GetMonster()
    {
        return m_pMonster;
    }
    #endregion


    #region Event Handler
    #endregion
}
