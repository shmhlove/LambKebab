using UnityEngine;
using System.Collections;

public static partial class SHHard
{
    public static string GetStickName(eStickType eType)
    {
        return string.Format("Widget_Stick_{0}", (int)eType);
    }

    public static string GetMonsterName(eMonsterType eType)
    {
        return string.Format("Widget_Monster_{0}", (int)eType);
    }
}
