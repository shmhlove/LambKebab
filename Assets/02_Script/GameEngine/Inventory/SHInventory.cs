using UnityEngine;
using System.Collections;

public partial class SHInventory : SHBaseEngine
{
    #region Virtual Functions
    public override void OnInitialize()
    {
        Clear();
        ShowCoinUI();
    }
    public override void OnFinalize() { }
    public override void OnFrameMove()
    {
        OnUpdateCoin();
        OnUpdateStick();
        OnUpdateMonster();
    }
    #endregion


    #region Interface Functions
    public void Clear()
    {
        InitCoin();
        InitStick();
        InitMonster();
    }
    #endregion


    #region Utility Functions
    #endregion
}
