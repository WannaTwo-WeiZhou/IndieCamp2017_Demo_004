using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fatty : Speaker
{
	void Update()
	{
		if (!m_CanMove) return;

		Mum mum = SpeakerManager.instance.m_Mum;
		if (mum.m_CurState == MumState.Following && mum.m_Visible &&
		mum.m_CurSceneIdx == 2)
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

		if (m_CurLineIdx_Night == 3)
		{
			if (!Global.instance.m_Hero.m_HoldPink)
			{
				m_CurLineIdx_Night = 2;
			}
		}

		if (m_CurLineIdx_Night == 4)
		{
			this.MoveAway();
		}
	}

	private void MoveAway()
	{

	}
}