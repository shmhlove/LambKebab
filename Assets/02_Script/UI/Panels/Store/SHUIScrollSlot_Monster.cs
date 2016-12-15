using UnityEngine;
using System;
using System.Collections;

public class SHUIScrollSlot_Monster : SHMonoWrapper
{
    #region Members : Inspector
    [SerializeField]  private GameObject m_pLeftSlot        = null;
    [SerializeField]  private GameObject m_pRightSlot       = null;
    [SerializeField]  private GameObject m_pLeftSelector    = null;
    [SerializeField]  private GameObject m_pRightSelector   = null;
    #endregion


    #region Members : Info
    [SerializeField]  public  eMonsterType      m_eLeftType     = eMonsterType.None;
    [SerializeField]  public  eMonsterType      m_eRightType    = eMonsterType.None;
    [HideInInspector] private SHUIWidge_Monster m_pLeftMonster  = null;
    [HideInInspector] private SHUIWidge_Monster m_pRightMonster = null;
    #endregion


    #region System Functions
    #endregion


    #region Virtual Functions
    #endregion


    #region Interface Functions
    public void Initialize(eMonsterType eType1, eMonsterType eType2)
    {
        ReturnStickObject(m_pLeftMonster);
        ReturnStickObject(m_pRightMonster);
        SetMonsterSlot((m_pLeftMonster  = CreateMonsterSlot((m_eLeftType  = eType1))), m_pLeftSlot);
        SetMonsterSlot((m_pRightMonster = CreateMonsterSlot((m_eRightType = eType2))), m_pRightSlot);
        
        SetSelector();
    }
    public void SetSelector()
    {
        // @_@ Stick상태처리(Lock, On, Off)
        // @_@ 금액처리

        if (null != m_pLeftSelector)
        {
            var eUseType = Single.Inventory.GetMonsterUseType(m_eLeftType);
            m_pLeftSelector.SetActive(eMonsterUseType.Enable == eUseType);
        }

        if (null != m_pRightSelector)
        {
            var eUseType = Single.Inventory.GetMonsterUseType(m_eRightType);
            m_pRightSelector.SetActive(eMonsterUseType.Enable == eUseType);
        }
    }
    #endregion


    #region Utility Functions
    void ReturnStickObject(SHUIWidge_Monster pMonster)
    {
        if (null == pMonster)
            return;

        Single.ObjectPool.Return(pMonster.GetGameObject());
    }
    SHUIWidge_Monster CreateMonsterSlot(eMonsterType eType)
    {
        if ((eMonsterType.None == eType) || (eMonsterType.Max == eType))
            return null;
        
        return Single.ObjectPool.Get<SHUIWidge_Monster>(SHHard.GetMonsterName(eType));
    }
    void SetMonsterSlot(SHUIWidge_Monster pMonster, GameObject pSlot)
    {
        if ((null == pMonster) || (null == pSlot))
            return;

        SHGameObject.SetParent(pMonster.GetGameObject(), pSlot);
        pMonster.Initialize(0.5f, 0.0f, 0.0f);
        pMonster.SetLocalPosition(Vector3.zero);
        pMonster.SetLocalScale(Vector3.one);
        pMonster.StopMoveTween();
        pMonster.SetActive(true);
    }
    #endregion
}
