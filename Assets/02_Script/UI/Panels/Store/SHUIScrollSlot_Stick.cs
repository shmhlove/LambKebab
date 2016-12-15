using UnityEngine;
using System;
using System.Collections;

public class SHUIScrollSlot_Stick : SHMonoWrapper
{
    #region Members : Inspector
    [SerializeField]  private GameObject m_pLeftSlot        = null;
    [SerializeField]  private GameObject m_pRightSlot       = null;
    [SerializeField]  private GameObject m_pLeftSelector    = null;
    [SerializeField]  private GameObject m_pRightSelector   = null;
    #endregion


    #region Members : Info
    [SerializeField]  public  eStickType      m_eLeftType   = eStickType.None;
    [SerializeField]  public  eStickType      m_eRightType  = eStickType.None;
    [HideInInspector] private SHUIWidge_Stick m_pLeftStick  = null;
    [HideInInspector] private SHUIWidge_Stick m_pRightStick = null;
    #endregion


    #region System Functions
    #endregion


    #region Virtual Functions
    #endregion


    #region Interface Functions
    public void Initialize(eStickType eType1, eStickType eType2)
    {
        ReturnStickObject(m_pLeftStick);
        ReturnStickObject(m_pRightStick);
        SetStickSlot((m_pLeftStick  = CreateStickSlot((m_eLeftType  = eType1))), m_pLeftSlot);
        SetStickSlot((m_pRightStick = CreateStickSlot((m_eRightType = eType2))), m_pRightSlot);
        
        SetSelector();
    }
    public void SetSelector()
    {
        // @_@ Stick상태처리(Lock, On, Off)
        // @_@ 금액처리

        if (null != m_pLeftSelector)
        {
            m_pLeftSelector.SetActive(m_eLeftType == Single.Inventory.m_eStickType);
        }

        if (null != m_pRightSelector)
        {
            m_pRightSelector.SetActive(m_eRightType == Single.Inventory.m_eStickType);
        }
    }
    #endregion


    #region Utility Functions
    void ReturnStickObject(SHUIWidge_Stick pStick)
    {
        if (null == pStick)
            return;

        Single.ObjectPool.Return(pStick.GetGameObject());
    }
    SHUIWidge_Stick CreateStickSlot(eStickType eType)
    {
        if ((eStickType.None == eType) || (eStickType.Max == eType))
            return null;
        
        return Single.ObjectPool.Get<SHUIWidge_Stick>(SHHard.GetStickName(eType));
    }
    void SetStickSlot(SHUIWidge_Stick pStick, GameObject pSlot)
    {
        if ((null == pStick) || (null == pSlot))
            return;

        SHGameObject.SetParent(pStick.GetGameObject(), pSlot);
        pStick.Initialize();
        pStick.SetLocalPosition(Vector3.zero);
        pStick.SetLocalScale(Vector3.one);
        pStick.SetActive(true);
    }
    #endregion
}
