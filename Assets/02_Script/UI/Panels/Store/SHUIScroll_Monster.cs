using UnityEngine;
using System;
using System.Collections;

using ListMonster = System.Collections.Generic.List<SHUIScrollSlot_Monster>;

public class SHUIScroll_Monster : SHUIMassiveScrollView
{
    #region Members : Inspector
    #endregion


    #region Members : Info
    private ListMonster m_pMonster = new ListMonster();
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
        var pMonster = pObject.GetComponent<SHUIScrollSlot_Monster>();
        pMonster.Initialize((eMonsterType)iType, (eMonsterType)(iType + 1));

        if (false == m_pMonster.Contains(pMonster))
            m_pMonster.Add(pMonster);
    }
    #endregion


    #region Interface Functions
    public void Initialize()
    {
        SetCellCount(GetMaxMonster() / 2);
    }
    #endregion


    #region Utility Functions
    int GetMaxMonster()
    {
        return (int)(eMonsterType.Max_NormalMonster - 1);
    }
    void RefleshSlotForSelect()
    {
        SHUtils.ForToList(m_pMonster, (pSlot) =>
        {
            pSlot.SetGoodsState();
        });
    }
    #endregion


    #region Event Handler
    public void OnClickToSlot(eMonsterType eType)
    {
        var eUseType = Single.Inventory.GetMonsterGoodsStateToPlayerPrefs(eType);
        switch(eUseType)
        {
            case eGoodsState.NotHas:
                // @_@ 구매처리
                Single.Inventory.SetMonsterTypeToPlayerPrefs(eType, eGoodsState.Enable);
                break;
            case eGoodsState.Disable:
                Single.Inventory.SetMonsterTypeToPlayerPrefs(eType, eGoodsState.Enable);
                break;
            case eGoodsState.Enable:
                Single.Inventory.SetMonsterTypeToPlayerPrefs(eType, eGoodsState.Disable);
                break;
        }
        RefleshSlotForSelect();
    }
    #endregion
}
