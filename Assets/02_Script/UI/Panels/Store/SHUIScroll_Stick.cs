﻿using UnityEngine;
using System;
using System.Collections;

public class SHUIScroll_Stick : SHUIMassiveScrollView
{
    #region Members : Inspector
    #endregion


    #region Members : Event
    #endregion


    #region System Functions
    #endregion


    #region Virtual Functions
    protected override void OnInitialized()
    {
        SetCellCount(10);
    }
    protected override void SetSlotData(GameObject pSlot, int iIndex)
    {
    }
    #endregion


    #region Interface Functions
    #endregion


    #region Utility Functions
    #endregion


    #region Event Handler
    #endregion
}