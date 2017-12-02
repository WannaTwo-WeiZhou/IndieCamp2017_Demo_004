using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerManager : MonoBehaviour {

	public static SpeakerManager instance { get; private set; }

	public Speaker m_ZhenZi;
	public Speaker m_CryingOldWoman;
	public Speaker m_Conductor;
	public Speaker m_Fatty;
	public Speaker m_Thin;
	public Speaker m_Handsome;
	public Speaker m_Beauty;
	public Speaker m_Mum;

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
