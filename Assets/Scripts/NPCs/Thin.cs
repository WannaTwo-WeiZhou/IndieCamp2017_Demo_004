using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thin : Speaker
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
            if (ExtensionManager.instance.m_Beauty)
            {
                this.MoveToTargetPos(1f, mum.transform.position);
            }
        }
    }

    public override void ShowText()
    {
        base.ShowText();

        if (!Global.instance.isNormal)
        {
            AudioManager.instance.PlayOnce(Constants.Noise_Hit);
        }
    }

    public override void LineComplete()
    {
        base.LineComplete();

        if (m_CurLineIdx_Night == 1)
        {
            Global.instance.m_Hero.GetPink();
        }
    }
}