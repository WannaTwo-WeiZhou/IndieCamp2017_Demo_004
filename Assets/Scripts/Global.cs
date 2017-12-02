using System.Collections;
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

    public void ChangeSpeakText(string newText)
    {
		m_SpeakText.text = "";

		float dur = newText.Length * m_PerCharDur;
        m_SpeakText.DOText(newText, dur);
    }
}
