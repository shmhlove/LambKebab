﻿using UnityEngine;
using System.Collections;

public partial class SHInventory : SHBaseEngine
{
    #region Members
    public int  m_iCoin     = 0;
    public int  m_iAddCoin  = 0;
    #endregion

    
    #region Interface Functions
    public void InitCoin()
    {
        m_iCoin     = GetCoin();
        m_iAddCoin  = 0;
    }
    public void OnUpdateCoin()
    {
        if (0 == m_iAddCoin)
            return;

        SetCoin(m_iCoin + m_iAddCoin);
        ShowCoinUI();
        m_iAddCoin = 0;
    }
    public void AddCoin(int iCoin)
    {
        m_iAddCoin += iCoin;
    }
    #endregion


    #region Utility Functions
    private void SetCoin(int iCoin)
    {
        SHPlayerPrefs.SetInt("Inventory_Coin", (m_iCoin = iCoin));
    }
    private int GetCoin()
    {
        return SHPlayerPrefs.GetInt("Inventory_Coin", 0);
    }
    public void ShowCoinUI()
    {
        Single.UI.Show("Panel_HUD", "Coin", m_iCoin);
    }
    #endregion
}
