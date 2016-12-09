﻿using UnityEngine;
using System;
using System.Collections;

public class SHUIPanel_ResultMenu : SHUIBasePanel
{
    #region Members : Inspector
    #endregion


    #region Members : Event
    private Action m_pEventToResultGame = null;
    #endregion


    #region System Functions
    #endregion


    #region Virtual Functions
    public override void OnBeforeShow(params object[] pArgs)
    {
        if ((null == pArgs) || (1 > pArgs.Length))
            return;

        m_pEventToResultGame = (Action)pArgs[0];
    }
    #endregion


    #region Interface Functions
    #endregion


    #region Utility Functions
    #endregion


    #region Event Handler
    public void OnClickToStartGame()
    {
        if (null == m_pEventToResultGame)
            return;

        m_pEventToResultGame();
        Close();
    }
	public void OnClickToStore()
	{
		Single.UI.Show ("Panel_Store");
	}
    #endregion
}
