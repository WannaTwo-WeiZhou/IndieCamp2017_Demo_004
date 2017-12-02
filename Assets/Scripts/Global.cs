﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour
{

    public static Global instance { get; private set; }

    public float m_PerCharDur = 0.2f;

    public Hero m_Hero;
    public Text m_SpeakText;
    [HideInInspector]
    public List<StateChange> m_StateChanges;
    public bool isNormal = true;

    void OnEnable()
    {
        if (Global.instance == null)
        {
            Global.instance = this;
        }
        else if (Global.instance != this)
        {
            Destroy(gameObject);
        }
    }
	void Start()
	{
		isNormal = true;
	}
    public void ChangeSpeakText(string newText)
    {
        m_SpeakText.text = "";

        float dur = newText.Length * m_PerCharDur;
        m_SpeakText.DOText(newText, dur);
    }
    public void TurnToNormalWorld()
    {
        if (isNormal)
        {
            return;
        }
        isNormal = true;
        CameraEffect.instance.MaskScenes();
        foreach (var one in m_StateChanges)
        {

            one.TurnToNormal();
        }
    }
    public void TurnToBeyondWorld()
    {
        if (isNormal == false)
        {
            return;
        }
        isNormal = false;
        CameraEffect.instance.MaskScenes();
        foreach (var one in m_StateChanges)
        {
            one.TurnToBeyond();
        }
    }

    public void GameOver()
    {

    }
}



