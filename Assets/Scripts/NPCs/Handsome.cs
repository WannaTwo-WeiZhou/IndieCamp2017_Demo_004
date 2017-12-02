using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handsome : Speaker
{
	public override void ShowText()
	{
		base.ShowText();
		
	}

	public override void LineComplete()
	{
		base.LineComplete();

		if (m_CurLineIdx_Night == 4)
		{
			if (!Global.instance.m_Hero.m_HoldArm)
			{
				m_CurLineIdx_Night = 3;
			}
		}

		if (m_CurLineIdx_Night == 5)
		{
			this.ShowDoorToScene4();
		}
	}

	private void ShowDoorToScene4()
	{

	}
}