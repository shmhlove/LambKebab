using UnityEngine;
using System.Collections;

public class SHRenderQueue : MonoBehaviour
{	
	public int m_RenderQueue = 3000;
    	
	void Start()
    {
        SetQueue();
    }

    [FuncButton]
    void SetQueue()
    {
        Transform[] pTransform = transform.GetComponentsInChildren<Transform>();
        foreach (Transform tr in pTransform)
        {
            Renderer pRenderer = tr.gameObject.GetComponent<Renderer>();
            if (null == pRenderer)
                continue;

            if (null == pRenderer.sharedMaterial)
                continue;
            
            pRenderer.sharedMaterial.renderQueue = m_RenderQueue;
        }
    }
}
