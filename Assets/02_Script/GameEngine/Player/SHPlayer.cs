using UnityEngine;
using System;
using System.Collections;

public class SHPlayer : SHBaseEngine
{
    #region Members : Info
    private SHUIWidge_Stick m_pStick = null;
    #endregion


    #region System Functions
    #endregion


    #region Interface Functions
    public void Start()
    {
        ClearStick();
        CreateStick();
    }
    public void Stop()
    {
        ClearStick();
    }
    #endregion


    #region Utility Functions
    private SHUIWidge_Stick CreateStick()
    {
        m_pStick = Single.ObjectPool.Get<SHUIWidge_Stick>(
            string.Format("Widget_Stick_{0}", GetStickType()));
        if (null == m_pStick)
            return null;
        
        SHGameObject.SetParent(m_pStick.transform, Single.UI.GetRootToScene());
        Single.ObjectPool.SetStartTransform(m_pStick.gameObject);
        m_pStick.SetActive(true);
        m_pStick.Initialize();

        return m_pStick;
    }
    void ClearStick()
    {
        if (null == m_pStick)
            return;

        Single.ObjectPool.Return(m_pStick.gameObject);
        m_pStick = null;
    }
    string GetStickType()
    {
        return SHPlayerPrefs.GetInt("StickType", 1).ToString();
    }
    #endregion


    #region Event Handler
    public void OnEventToTouch(Action pEventToPass)
    {
        if (null == m_pStick)
            return;

        m_pStick.Shoot(pEventToPass);
        SHCoroutine.Instance.WaitTime(() => CreateStick(), m_pStick.m_fReCreateTime);
        m_pStick = null;
    }
    #endregion
}