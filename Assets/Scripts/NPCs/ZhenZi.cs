﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ZhenZi : Speaker
{

	public override void ShowText()
	{
		base.ShowText();
		
	}

	public override void LineComplete()
	{
		base.LineComplete();

		if (m_CurLineIdx_Day == 4)
		{
			// unlock bell


			
		}

		if (SpeakerManager.instance.m_Mum.m_CurLineIdx_Night != 3)
		{
			if (m_CurLineIdx_Night == 1)
			{
				m_CurLineIdx_Night = 0;
			}
		}
	}
}