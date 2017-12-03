using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fatty : Speaker
{
	protected override void Update()
	{
		if (m_CarIdx == Global.instance.m_CarIndex)
		{
			this.SetVisible(true);
		}
		else
		{
			this.SetVisible(false);
			return;
		}

		if (!m_CanMove) return;

		Mum mum = SpeakerManager.instance.m_Mum;
		if (mum.m_CurState == MumState.Following && mum.m_Visible &&
		mum.m_CurSceneIdx == m_CarIdx)
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
		Vector3 newPos = new Vector3(-2f, 0, 0);
		transform.Translate(newPos);
	}
}