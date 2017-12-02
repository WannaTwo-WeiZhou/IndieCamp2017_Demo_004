using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public List<StateChange> m_StateChanges; 
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	public void TurnToNormalWorld()
	{
		CameraEffect.instance.MaskScenes();
		foreach(var one in m_StateChanges)
		{
			
			one.TurnToNormal();
		}
	}
	public void TurnToBeyondWorld()
	{
		CameraEffect.instance.MaskScenes();
		foreach(var one in m_StateChanges)
		{
			one.TurnToBeyond();
		}
	}
}
