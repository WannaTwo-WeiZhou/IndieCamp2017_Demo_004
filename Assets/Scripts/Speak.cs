using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speak : MonoBehaviour
{
	public List<string> m_Texts = new List<string>();

	private int m_CurIdx = 0;

	void Awake()
	{
		m_CurIdx = 0;
	}

    public void ShowText()
	{
		if (m_CurIdx >= m_Texts.Count) return;

		Global.instance.ChangeSpeakText(m_Texts[m_CurIdx]);
		m_CurIdx ++;
	}
}
