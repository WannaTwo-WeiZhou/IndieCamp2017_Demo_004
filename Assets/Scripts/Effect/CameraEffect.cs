using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraEffect : MonoBehaviour
{
    public static CameraEffect instance;
    public GameObject m_MaskGO;
    void Awake()

    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    public void MaskScenes()
    {
		m_MaskGO.SetActive(true);
        SpriteRenderer sp = m_MaskGO.GetComponent<SpriteRenderer>();
		sp.DOFade(1,0.01f);
        sp.DOFade(0f, 2f);
    }
}
