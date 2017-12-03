using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thin : Speaker
{

    void Update()
    {
		if (!m_CanMove) return;

        Mum mum = SpeakerManager.instance.m_Mum;
        if (mum.m_CurState == MumState.Following && mum.m_Visible &&
        mum.m_CurSceneIdx == 2)
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