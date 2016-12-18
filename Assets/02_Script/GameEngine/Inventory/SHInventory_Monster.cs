using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using DicMonsters = System.Collections.Generic.Dictionary<eMonsterType, eMonsterUseType>;

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
    Max_NormalMonster,
    Monster_Bonus,
    Max
}

public enum eMonsterUseType
{
    NotHas      = -1,
    Disable     = 0,
    Enable      = 1,
}

public partial class SHInventory : SHBaseEngine
{
    /*
     PlayerPreb와
     Dic에 담아쓰는것을 구분짓고,
        1은 상점에서만
        2는 플레이 중에만 참조할 수 있도록
    */
    
    #region Members : Info
    private DicMonsters m_dicMonsterInfo = new DicMonsters();
    #endregion


    #region Members : Constants
    private int MIN_ENABLE_COUNT = 5;
    #endregion


    #region Interface : System
    public void InitMonster()
    {
        RegisterBasicMonster();
        ResetMonsterInfo();
    }
    public void OnUpdateMonster()
    {

    }
    #endregion


    #region Interface : Dic Helpper
    public List<eMonsterType> GetEnableMonstersForDic()
    {
        var pResult = new List<eMonsterType>();
        SHUtils.ForToDic(m_dicMonsterInfo, (pKey, pValue) =>
        {
            if (eMonsterUseType.Enable != pValue)
                return;

            pResult.Add(pKey);
        });

        return pResult;
    }
    #endregion


    #region Interface : PlayerPrefs Helpper
    public void SetMonsterTypeToPlayerPrefs(eMonsterType eMonType, eMonsterUseType eUseType)
    {
        if (eMonsterUseType.Disable == eUseType)
        {
            if (MIN_ENABLE_COUNT >= GetEnableMonstersToPlayerPrefs().Count)
            {
                Single.UI.ShowNotice("알림", "몬스터는 최소 5마리 이상입니다.");
                return;
            }
        }

        SHPlayerPrefs.SetInt(string.Format("Inventory_Monste_{0}", (int)eMonType), (int)eUseType);
    }
    public eMonsterUseType GetMonsterUseTypeToPlayerPrefs(eMonsterType eType)
    {
        return (eMonsterUseType)SHPlayerPrefs.GetInt(
            string.Format("Inventory_Monste_{0}", (int)eType), (int)eMonsterUseType.NotHas);
    }
    public List<eMonsterType> GetEnableMonstersToPlayerPrefs()
    {
        var pResult = new List<eMonsterType>();
        SHUtils.ForToEnum<eMonsterType>((eType) =>
        {
            if (false == IsEnableToPlayerPrefs(eType))
                return;

            pResult.Add(eType);
        });

        return pResult;
    }
    public bool IsHasToPlayerPrefs(eMonsterType eType)
    {
        return (eMonsterUseType.NotHas != GetMonsterUseTypeToPlayerPrefs(eType));
    }
    public bool IsEnableToPlayerPrefs(eMonsterType eType)
    {
        return (eMonsterUseType.Enable == GetMonsterUseTypeToPlayerPrefs(eType));
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
        if (true == IsHasToPlayerPrefs(eType))
            return;

        SetMonsterTypeToPlayerPrefs(eType, eMonsterUseType.Enable);
    }
    void ResetMonsterInfo()
    {
        m_dicMonsterInfo.Clear();
        SHUtils.ForToEnum<eMonsterType>((eType) =>
        {
            if ((eMonsterType.None == eType)              ||
                (eMonsterType.Max_NormalMonster == eType) ||
                (eMonsterType.Max == eType))
                return;

            m_dicMonsterInfo.Add(eType, GetMonsterUseTypeToPlayerPrefs(eType));
        });
    }
    #endregion
}
