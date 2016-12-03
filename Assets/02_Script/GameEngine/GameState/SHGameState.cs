using UnityEngine;
using System.Collections;

public class SHGameState : SHBaseEngine
{
    #region Members
    public int  m_iScore     = 0;
    #endregion


    #region Virtual Functions
    public override void OnInitialize() { }
    public override void OnFinalize() { }
    public override void OnFrameMove() { }
    #endregion


    #region Interface Functions
    public void AddScore(int iScore)
    {
        m_iScore += iScore;
        // 점수연출 : 쌓아놓고 다음 프레임에 한방에 올려주도록
    }
    #endregion


    #region Utility Functions
    #endregion


    #region Event Handler
    #endregion
}
