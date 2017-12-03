using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
	public int m_CarIdx = 1;
	public bool m_Visible = true;

	public List<string> m_Texts_Day = new List<string>();
	public List<string> m_Texts_Night = new List<string>();

	public int m_CurLineIdx_Day = 0;
	public int m_CurLineIdx_Night = 0;

	protected bool m_CanMove = true;

	protected virtual void Awake()
	{
		m_CurLineIdx_Day = 0;
		m_CurLineIdx_Night = 0;
		m_CanMove = true;
	}

	protected virtual void Update()
    {
        if (m_CarIdx == Global.instance.m_CarIndex)
        {
            this.SetVisible(true);
        }
        else
        {
            this.SetVisible(false);
            return;
        }
    }

	protected void SetVisible(bool val)
	{
		m_Visible = val;

		Collider2D col = GetComponent<Collider2D>();
        col.enabled = val;
        Renderer ren = GetComponentInChildren<Renderer>();
        if (ren != null)
        {
            ren.enabled = val;
        }
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

	public void MoveToTargetPos(float vec, Vector3 pos)
    {
        if (Vector3.Distance(transform.position, pos) <
           Time.deltaTime * vec)
        {
            transform.position = pos;

        }
        else
        {
            Vector3 translateVec = (pos - transform.position).normalized *
               ( vec * Time.deltaTime);
            transform.Translate(translateVec);
        }
    }

	public void StopMoving()
	{
        Collider2D col = GetComponent<Collider2D>();
		if (col != null)
		{
			col.enabled = false;
		}
		m_CanMove = false;
	}
}
