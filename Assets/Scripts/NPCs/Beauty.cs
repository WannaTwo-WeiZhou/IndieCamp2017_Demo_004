using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beauty : Speaker
{
	public override void ShowText()
	{
		base.ShowText();
		
	}

	public override void LineComplete()
	{
		base.LineComplete();

		if (m_CurLineIdx_Night == 1)
		{
			ExtensionManager.instance.m_Beauty = true;
		}
	}
}
