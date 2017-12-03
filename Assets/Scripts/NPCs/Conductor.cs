using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Conductor : Speaker
{
	void Update()
	{
		if (!m_CanMove) return;

		Mum mum = SpeakerManager.instance.m_Mum;
		if (mum.m_CurState == MumState.Following && mum.m_Visible &&
		mum.m_CurSceneIdx == 1)
		{
			this.MoveToTargetPos(1f, mum.transform.position);
		}
	}

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
				Global.instance.m_Hero.GetPassCard();
			}
		}
	}
}