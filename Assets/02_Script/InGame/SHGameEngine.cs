using UnityEngine;
using System;
using System.Collections;

public class SHGameEngine : SHSingleton<SHGameEngine>
{
    #region Members
    // 게임스텝 메니져
    /*  플로우
        시작
        플레이
        결과
        재시도 
    */
    #endregion


    #region Virtual Functions
    public override void OnInitialize() { }
    public override void OnFinalize() { }
    #endregion


    #region System Functions
    #endregion


    #region Interface Functions
    public void StartEngine()
    {
        Single.UI.Show("Panel - StartMenu", (Action)OnEventToStartGame);
    }

    public void FrameMove()
    {

    }
    #endregion


    #region Event Handler
    public void OnEventToStartGame()
    {
        Single.UI.ShowNotice_NoMake();
    }
    #endregion
}
