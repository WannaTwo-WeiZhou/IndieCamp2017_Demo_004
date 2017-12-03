using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ZhenZi : Speaker
{

    public override void ShowText()
    {
        base.ShowText();

        if (SpeakerManager.instance.m_Mum.m_CurState == MumState.Following)
        {
            SpeakerManager.instance.m_Mum.ChangeState(MumState.FinalSpeaking);
        }
    }

    public override void LineComplete()
    {
        base.LineComplete();

        if (m_CurLineIdx_Day == 4)
        {
            // unlock bell



        }

        if (m_CurLineIdx_Night == 1)
        {
            m_CurLineIdx_Night = 0;
        }
		else if (m_CurLineIdx_Night >= 2 && m_CurLineIdx_Night < 4)
		{
			this.ShowText();
		}
		else if (m_CurLineIdx_Night == 4)
		{
			Global.instance.FinalResult();
		}
    }
}