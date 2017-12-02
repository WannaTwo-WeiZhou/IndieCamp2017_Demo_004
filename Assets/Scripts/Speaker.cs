using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
	public List<string> m_Texts = new List<string>();

	protected int m_CurIdx = 0;

	protected virtual void Awake()
	{
		m_CurIdx = 0;
	}

	protected virtual void AdditionalAction()
	{

	}

    public void ShowText()
	{
		if (m_CurIdx >= m_Texts.Count) return;

		Global.instance.ChangeSpeakText(m_Texts[m_CurIdx]);
		// m_CurIdx ++;

		this.AdditionalAction();
	}
}
