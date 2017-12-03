using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerManager : MonoBehaviour {

	public static SpeakerManager instance { get; private set; }

	public ZhenZi m_ZhenZi;
	public CryingOldWoman m_CryingOldWoman;
	public Conductor m_Conductor;
	public Fatty m_Fatty;
	public Thin m_Thin;
	public Handsome m_Handsome;
	public Beauty m_Beauty;
	public Mum m_Mum;

	void OnEnable()
	{
		if (SpeakerManager.instance == null)
		{
			SpeakerManager.instance = this;
		}
		else if (SpeakerManager.instance != this)
		{
			Destroy(gameObject);
		}
	}

}
