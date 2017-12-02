using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChange : MonoBehaviour {

	private SpriteRenderer m_SR;
	public Sprite m_NormalSprite;
	public Sprite m_BeyondSprite;
	void Awake()
	{
		m_SR = gameObject.GetComponent<SpriteRenderer>();
	}
	void Start()
	{
		Global.instance.m_StateChanges.Add(this);
	}

	public void TurnToNormal()
	{
		m_SR.sprite = m_NormalSprite;	
	}
	public void TurnToBeyond()
	{
		m_SR.sprite = m_BeyondSprite;	
	}
}
