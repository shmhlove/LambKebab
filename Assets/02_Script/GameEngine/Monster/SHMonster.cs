﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using Monsters = System.Collections.Generic.List<SHUIWidge_Monster>;

public class SHMonster : SHBaseEngine
{
    #region Members : Object
    private Monsters m_pMonsters = new Monsters();
    #endregion


    #region Members : Info
    private bool bIsCheckCreateMonster = false;
    #endregion


    #region Members : Constants
    private readonly float MIN_CREATE_POS_Y = 50;
    private readonly float MAX_CREATE_POS_Y = 500;
    #endregion


    #region Virtual Functions
    public override void OnFrameMove()
    {
        if (false == bIsCheckCreateMonster)
            return;

        CheckDeleteMonster();
        CheckCreateMonster();
    }
    #endregion


    #region Interface Functions
    public void Start()
    {
        bIsCheckCreateMonster = true;
        ClearMonster();

        var pMonster = AddMonster(CreateMonster("4", 0.5f, 250.0f)); 
        pMonster.StopMoveTween();
    }
    public void Stop()
    {
        bIsCheckCreateMonster = false;
    }
    public Monsters GetMonsters()
    {
        return m_pMonsters;
    }
    #endregion


    #region Utility Functions
    private void CheckDeleteMonster()
    {
        var pDelete = new Monsters(m_pMonsters);
        SHUtils.ForToList(pDelete, (pMonster) =>
        {
            if (false == pMonster.IsDie())
                return;

            m_pMonsters.Remove(pMonster);
        });
    }
    private void CheckCreateMonster()
    {
        if (0 != m_pMonsters.Count)
            return;

        var pMonster = CreateMonster(GetMonsterType(), GetRandomFactor(), SHMath.Random(MIN_CREATE_POS_Y, MAX_CREATE_POS_Y));
        pMonster.PlayMoveTween();
        AddMonster(pMonster);
    }
    private SHUIWidge_Monster AddMonster(SHUIWidge_Monster pMonster)
    {
        if (null != pMonster)
        {
            m_pMonsters.Add(pMonster);
        }
        return pMonster;
    }
    private SHUIWidge_Monster CreateMonster(string strKinds, float fFactor, float fStartPosY)
    {
        var pMonster = Single.ObjectPool.Get<SHUIWidge_Monster>(
            string.Format("Widget_Monster_{0}", strKinds));
        if (null == pMonster)
            return null;

        SHGameObject.SetParent(pMonster.transform, Single.UI.GetRootToScene());
        Single.ObjectPool.SetStartTransform(pMonster.gameObject);
        pMonster.SetActive(true);
        pMonster.Initialize(fFactor, fStartPosY);
        return pMonster;
    }
    private float GetRandomFactor()
    {
        return SHMath.RandomN(new List<float>(){0.0f, 1.0f});
    }
    private string GetMonsterType()
    {
        return SHMath.RandomW(
            new List<string>() { "1",  "2",  "3",  "4", },
            new List<float>()  { 0.1f, 0.2f, 0.4f, 0.5f, });
    }
    void ClearMonster()
    {
        SHUtils.ForToList(m_pMonsters, (pMonster) =>
        {
            pMonster.SetActive(false);
        });

        m_pMonsters.Clear();
    }
    #endregion


    #region Event Handler
    #endregion
}