using UnityEngine;
using System.Collections;

public enum eStickType
{
    None,
    Stick_1,
    Stick_2,
    Stick_3,
    Stick_4,
    Stick_5,
    Stick_6,
    Stick_7,
    Stick_8,
    Stick_9,
    Stick_10,
    Stick_11,
    Stick_12,
    Stick_13,
    Stick_14,
    Stick_15,
    Max,
}

public partial class SHInventory : SHBaseEngine
{
    #region Members
    public eStickType m_eStickType { get; private set; }
    #endregion

    
    #region Interface Functions
    public void InitStick()
    {
        m_eStickType = GetStickType();
    }
    public void OnUpdateStick()
    {

    }
    public void ChangeStick(eStickType eType)
    {
        SetStickType(eType);
    }
    #endregion


    #region Utility Functions
    private void SetStickType(eStickType eType)
    {
        SHPlayerPrefs.SetInt("Inventory_Stick", (int)(m_eStickType = eType));
    }
    private eStickType GetStickType()
    {
        return (eStickType)SHPlayerPrefs.GetInt("Inventory_Stick", (int)eStickType.Stick_1);
    }
    #endregion
}
