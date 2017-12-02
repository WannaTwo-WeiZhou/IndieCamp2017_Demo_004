using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mum : Speaker
{
	public void StartMyAction()
	{
		Global.instance.TurnToBeyondWorld();
		this.ShowText();
	}

	public override void ShowText()
	{
		base.ShowText();
		
	}

	public override void LineComplete()
	{
		base.LineComplete();

		if (!Global.instance.isNormal)
		{
			if (m_CurLineIdx_Night == 3)
			{
				SpeakerManager.instance.m_ZhenZi.m_CurLineIdx_Night = 1;
				this.StartAttack();
			}
			else
			{
				this.ShowText();
			}
		}
	}

	private void StartAttack()
	{

	}
}