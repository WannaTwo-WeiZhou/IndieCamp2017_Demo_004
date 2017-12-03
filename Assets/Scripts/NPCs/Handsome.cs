using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handsome : Speaker
{
	void Update()
	{
		if (!m_CanMove) return;

		Mum mum = SpeakerManager.instance.m_Mum;
		if (mum.m_CurState == MumState.Following && mum.m_Visible &&
		mum.m_CurSceneIdx == 3)
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