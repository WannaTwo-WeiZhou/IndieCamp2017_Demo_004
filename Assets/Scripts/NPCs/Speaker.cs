using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
	public List<string> m_Texts_Day = new List<string>();
	public List<string> m_Texts_Night = new List<string>();

	public int m_CurLineIdx_Day = 0;
	public int m_CurLineIdx_Night = 0;

	protected virtual void Awake()
	{
		m_CurLineIdx_Day = 0;
		m_CurLineIdx_Night = 0;
	}

    public virtual void ShowText()
	{
		if (Global.instance.isNormal)
		{
			if (m_Texts_Day.Count <= 0) return;
			m_CurLineIdx_Day = m_CurLineIdx_Day >= m_Texts_Day.Count?
				m_Texts_Day.Count - 1:
				m_CurLineIdx_Day;
			Global.instance.ChangeSpeakText(
				m_Texts_Day[m_CurLineIdx_Day], this);
		}
		else
		{
			if (m_Texts_Night.Count <= 0) return;
			m_CurLineIdx_Night = m_CurLineIdx_Night >= m_Texts_Night.Count?
				m_Texts_Night.Count - 1:
				m_CurLineIdx_Night;
			Global.instance.ChangeSpeakText(
				m_Texts_Night[m_CurLineIdx_Night], this);
		}
		
	}

	public virtual void LineComplete()
	{
		// Debug.Log(gameObject.name + " line complete!!!");
		if (Global.instance.isNormal)
		{
			m_CurLineIdx_Day++;
		}
		else
		{
			m_CurLineIdx_Night++;
		}
	}
}
