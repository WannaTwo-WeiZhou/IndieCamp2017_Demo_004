using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

	public static Global instance { get; private set; }

	public Hero m_Hero;

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


}
