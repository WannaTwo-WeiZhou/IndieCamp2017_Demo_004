using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Conductor : Speaker
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