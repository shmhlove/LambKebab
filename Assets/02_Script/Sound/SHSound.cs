using UnityEngine;
using System;
using System.Collections;

public class SHSound : SHSingleton<SHSound>
{
    #region Members
    private AudioSource m_pChannelBGM = null;
    #endregion


    #region Virtual Functions
    public override void OnInitialize()
    {
        m_pChannelBGM = SHGameObject.GetComponent<AudioSource>(gameObject);
        m_pChannelBGM.loop = true;
    }
    public override void OnFinalize()
    {
        StopAllCoroutines();
    }
    #endregion


    #region Interface Functions
    public void PlayBGM()
    {
        if (null == m_pChannelBGM.clip)
            m_pChannelBGM.clip = Single.Resource.GetSound("Audio_Pineapple");

        m_pChannelBGM.volume = 0.0f;
        m_pChannelBGM.Play();
        StartCoroutine(CoroutineVolumeUP());
    }

    public void StopBGM()
    {
        StartCoroutine(CoroutineVolumeDown(m_pChannelBGM.Stop));
    }
    #endregion


    #region Coroutine Functions
    private IEnumerator CoroutineVolumeUP()
    {
        if (null == m_pChannelBGM)
            yield break;
        
        while(1.0f != m_pChannelBGM.volume)
        {
            m_pChannelBGM.volume += 0.02f;
            Mathf.Clamp(m_pChannelBGM.volume, 0.0f, 1.0f);
            yield return null;
        }
    }
    private IEnumerator CoroutineVolumeDown(Action pEndCallback)
    {
        if (null == m_pChannelBGM)
            yield break;

        while (0.0f != m_pChannelBGM.volume)
        {
            m_pChannelBGM.volume -= 0.02f;
            Mathf.Clamp(m_pChannelBGM.volume, 0.0f, 1.0f);
            yield return null;
        }

        pEndCallback();
    }
    #endregion
}
