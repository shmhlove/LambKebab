using UnityEngine;
using System.Collections;

public class SHScoreBoard : SHBaseEngine
{
    #region Members
    public int  m_iScore     = 0;
    public int  m_iAddScore  = 0;
    #endregion


    #region Virtual Functions
    public override void OnInitialize() { }
    public override void OnFinalize() { }
    public override void OnFrameMove()
    {
        if (0 == m_iAddScore)
            return;

        SetScore(m_iScore + m_iAddScore);
        ShowCurrentScore();
        m_iAddScore = 0;
    }
    #endregion


    #region Interface Functions
    public void Start()
    {
        m_iScore    = 0;
        m_iAddScore = 0;
        CloseScoreBoard();
    }
    public void ShowCurrentScore()
    {
        Single.UI.Show("Panel_ScoreBoard", "Current", m_iScore);
    }
    public void ShowBestScore()
    {
        Single.UI.Show("Panel_ScoreBoard", "Best", GetBestScore());
    }
    public void CloseScoreBoard()
    {
        Single.UI.Close("Panel_ScoreBoard");
    }
    public void AddScore(int iScore)
    {
        m_iAddScore += iScore;
    }
    #endregion


    #region Utility Functions
    private void SetScore(int iScore)
    {
        m_iScore = iScore;

        if (GetBestScore() < m_iScore)
            SetBestScore(m_iScore);
    }
    private void SetBestScore(int iScore)
    {
        SHPlayerPrefs.SetInt("BestScore", iScore);
    }
    private int GetBestScore()
    {
        return SHPlayerPrefs.GetInt("BestScore", 0);
    }
    #endregion


    #region Event Handler
    #endregion
}
