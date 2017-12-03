using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handsome : Speaker
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
		
		if (!Global.instance.isNormal && m_CurLineIdx_Night == 0)
        {
            AudioManager.instance.PlayOnce(Constants.Noise_Shine);
        }
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