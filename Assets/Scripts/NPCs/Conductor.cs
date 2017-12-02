using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Conductor : Speaker
{
	private const string PASSCARDTAG = "PassCard";
	
	public override void ShowText()
	{
		base.ShowText();
		
	}

	public override void LineComplete()
	{
		base.LineComplete();

		if (m_CurLineIdx_Night == 2)
		{
			// unlock pass card
			if (!Global.instance.m_Hero.m_HoldPassCard)
			{
				Global.instance.m_Hero.m_HoldPassCard = true;

				// show card
				GameObject passCard = GameObject.
					FindGameObjectWithTag(PASSCARDTAG);
				if (passCard != null)
				{
					Image img = passCard.GetComponent<Image>();
					img.DOFade(1f, 1f);
				}
			}
		}
	}
}