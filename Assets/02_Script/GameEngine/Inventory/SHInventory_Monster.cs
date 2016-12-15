using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum eMonsterType
{
    None,
    Monster_1,
    Monster_2,
    Monster_3,
    Monster_4,
    Monster_5,
    Monster_6,
    Monster_7,
    Monster_8,
    Monster_9,
    Monster_10,
    Monster_11,
    Monster_12,
    Monster_13,
    Monster_14,
    Monster_15,
    Max,
}

public enum eMonsterUseType
{
    NotHas      = -1,
    Disable     = 0,
    Enable      = 1,
}

public partial class SHInventory : SHBaseEngine
{
    #region Members : Constants
    private int MIN_ENABLE_COUNT = 5;
    #endregion

    #region Interface : System
    public void InitMonster()
    {
        RegisterBasicMonster();
    }
    public void OnUpdateMonster()
    {

    }
    #endregion


    #region Interface : Helpper
    public List<eMonsterType> GetHasMonsters()
    {
        var pResult = new List<eMonsterType>();
        SHUtils.ForToEnum<eMonsterType>((eType) =>
        {
            if (false == IsHas(eType))
                return;

            pResult.Add(eType);
        });

        return pResult;
    }
    public List<eMonsterType> GetEnableMonsters()
    {
        var pResult = new List<eMonsterType>();
        SHUtils.ForToEnum<eMonsterType>((eType) =>
        {
            if (false == IsEnable(eType))
                return;

            pResult.Add(eType);
        });

        return pResult;
    }
    public bool IsHas(eMonsterType eType)
    {
        return (eMonsterUseType.NotHas != GetMonsterUseType(eType));
    }
    public bool IsEnable(eMonsterType eType)
    {
        return (eMonsterUseType.Enable == GetMonsterUseType(eType));
    }
    #endregion


    #region Utility Functions
    private void RegisterBasicMonster()
    {
        RegisterMonster(eMonsterType.Monster_1);
        RegisterMonster(eMonsterType.Monster_2);
        RegisterMonster(eMonsterType.Monster_3);
        RegisterMonster(eMonsterType.Monster_4);
        RegisterMonster(eMonsterType.Monster_5);
    }
    private void RegisterMonster(eMonsterType eType)
    {
        if (true == IsHas(eType))
            return;

        SetMonsterType(eType, eMonsterUseType.Enable);
    }
    public void SetMonsterType(eMonsterType eMonType, eMonsterUseType eUseType)
    {
        if (eMonsterUseType.Disable == eUseType)
        {
            if (MIN_ENABLE_COUNT >= GetEnableMonsters().Count)
            {
                Single.UI.ShowNotice("알림", "몬스터는 최소 5마리 이상입니다.");
                return;
            }
        }

        SHPlayerPrefs.SetInt(string.Format("Inventory_Monste_{0}", (int)eMonType), (int)eUseType);
    }
    public eMonsterUseType GetMonsterUseType(eMonsterType eType)
    {
        return (eMonsterUseType)SHPlayerPrefs.GetInt(
            string.Format("Inventory_Monste_{0}", (int)eType), (int)eMonsterUseType.NotHas);
    }

    #endregion
}
