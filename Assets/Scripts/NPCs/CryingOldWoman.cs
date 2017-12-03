﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryingOldWoman : Speaker
{
	void Update()
	{
		if (!m_CanMove) return;

		Mum mum = SpeakerManager.instance.m_Mum;
		if (mum.m_CurState == MumState.Following && mum.m_Visible &&
		mum.m_CurSceneIdx == 1)
		{
			if (ExtensionManager.instance.m_OldWoman)
			{
				this.MoveToTargetPos(1f, mum.transform.position);
			}
		}
	}

	public override void ShowText()
	{
		base.ShowText();
		
	}

	public override void LineComplete()
	{
		base.LineComplete();

		if (m_CurLineIdx_Night == 1)
		{
			ExtensionManager.instance.m_OldWoman = true;
		}
	}
}