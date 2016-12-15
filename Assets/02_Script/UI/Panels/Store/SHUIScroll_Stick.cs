using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using ListStick = System.Collections.Generic.List<SHUIScrollSlot_Stick>;

public class SHUIScroll_Stick : SHUIMassiveScrollView
{
    #region Members : Inspector
    #endregion


    #region Members : Info
    private ListStick m_pSticks = new ListStick();
    #endregion


    #region System Functions
    #endregion


    #region Virtual Functions
    protected override void OnInitialized()
    {
        Initialize();
    }
    protected override void SetSlotData(GameObject pObject, int iIndex)
    {
        int iType = (iIndex * 2) + 1;
        var pSlot = pObject.GetComponent<SHUIScrollSlot_Stick>();
        pSlot.Initialize((eStickType)iType, (eStickType)(iType + 1));

        if (false == m_pSticks.Contains(pSlot))
            m_pSticks.Add(pSlot);
    }
    #endregion


    #region Interface Functions
    public void Initialize()
    {
        SetCellCount(GetMaxStick() / 2);
    }
    #endregion


    #region Utility Functions
    int GetMaxStick()
    {
        return (int)(eStickType.Max - 1);
    }
    void RefleshSlotForSelect()
    {
        SHUtils.ForToList(m_pSticks, (pSlot) =>
        {
            pSlot.SetSelector();
        });
    }
    #endregion


    #region Event Handler
    public void OnClickToSlot(eStickType eType)
    {
        Single.Inventory.ChangeStick(eType);
        RefleshSlotForSelect();
    }
    #endregion
}