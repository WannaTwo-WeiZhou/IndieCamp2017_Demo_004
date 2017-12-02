using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtensionManager : MonoBehaviour
{

    public static ExtensionManager instance { get; private set; }

    public bool m_OldWoman = false;
    public bool m_Beauty = false;


    void OnEnable()
    {
        if (ExtensionManager.instance == null)
        {
            ExtensionManager.instance = this;
        }
        else if (ExtensionManager.instance != this)
        {
            Destroy(gameObject);
        }
    }


    void Awake()
    {
        m_OldWoman = false;
        m_Beauty = false;
    }
}
