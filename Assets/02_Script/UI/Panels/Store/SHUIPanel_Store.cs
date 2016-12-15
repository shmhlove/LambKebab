using UnityEngine;
using System;
using System.Collections;

public class SHUIPanel_Store : SHUIBasePanel
{
    #region Members : Inspector
    [SerializeField] private SHUIScroll_Stick   m_pStickTab   = null;
    [SerializeField] private SHUIScroll_Monster m_pMonsterTab = null;
    #endregion


    #region Members : Event
    #endregion


    #region System Functions
    #endregion


    #region Virtual Functions
    public override void OnBeforeShow(params object[] pArgs)
    {
        OnToggleToStick(true);
        OnToggleToMonster(false);
    }
    #endregion


    #region Interface Functions
    #endregion


    #region Utility Functions
    #endregion


    #region Event Handler
    public void OnToggleToStick(bool bIsOn)
    {
        if (null == m_pStickTab)
            return;

        if (true == bIsOn)
            m_pStickTab.Initialize();

        m_pStickTab.gameObject.SetActive(bIsOn);
    } 
	public void OnToggleToMonster(bool bIsOn)
	{
        if (null == m_pMonsterTab)
            return;

        if (true == bIsOn)
            m_pMonsterTab.Initialize();

        m_pMonsterTab.gameObject.SetActive(bIsOn);
    }
    #endregion
}
