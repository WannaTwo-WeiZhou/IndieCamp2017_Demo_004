using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
	public string m_Texts_Day = "- Day -";
	public string m_Texts_Night = "- Night -";


	protected virtual void Awake()
	{
		
	}

	protected virtual void AdditionalAction()
	{

	}

    public void ShowText()
	{
		this.AdditionalAction();
		
		if (Global.instance.isNormal)
		{
			Global.instance.ChangeSpeakText(m_Texts_Day);
		}
		else
		{
			Global.instance.ChangeSpeakText(m_Texts_Night);
		}
		
	}
}
