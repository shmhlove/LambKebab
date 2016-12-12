using UnityEngine;
using System.Collections;

public partial class SHInventory : SHBaseEngine
{
    #region Members
    public int  m_iStickType = 0;
    #endregion

    
    #region Interface Functions
    public void InitStick()
    {
        m_iStickType = GetStickType();
    }
    public void OnUpdateStick()
    {

    }
    public void ChangeStick(int iType)
    {
        SetStickType(iType);
    }
    #endregion


    #region Utility Functions
    private void SetStickType(int iType)
    {
        SHPlayerPrefs.SetInt("Inventory_Stick", (m_iStickType = iType));
    }
    private int GetStickType()
    {
        return SHPlayerPrefs.GetInt("Inventory_Stick", 1);
    }
    #endregion
}
