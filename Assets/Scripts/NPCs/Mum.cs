using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MumState
{
    NULL = -1,

    Speaking = 0,
    Following = 1,
    FinalSpeaking = 2,

    SIZE

};

public class Mum : Speaker
{
    public MumState m_CurState = MumState.NULL;
    public float m_MoveVec = 3f;
    public float m_SlowDownVec = 0.2f;
    public bool m_Visible = true;
	public int m_CurSceneIdx = 4;

    private Transform m_Trans;
    private IEnumerator m_IE_SlowDown = null;
    private float m_CurVec = 0f;

    protected override void Awake()
    {
		base.Awake();

        m_Trans = transform;
        m_CurState = MumState.NULL;
        m_Visible = true;
        m_IE_SlowDown = null;
        m_CurVec = m_MoveVec;
		m_CurSceneIdx = 4;
    }

    void Update()
    {
		if (m_CurState == MumState.NULL)
		{
			// check global's scene idx and call StartMyAction()
		}
        if (m_CurState == MumState.Following && m_Visible)
        {
            Vector3 heroPos = Global.instance.m_Hero.transform.position;

            this.MoveToTargetPos(m_CurVec, heroPos);
        }
    }

    public void StartMyAction()
    {
		this.ChangeState(MumState.Speaking);
        // Global.instance.TurnToBeyondWorld();
        this.ShowText();
    }

    public override void ShowText()
    {
        base.ShowText();

    }

    public override void LineComplete()
    {
        base.LineComplete();

        if (!Global.instance.isNormal)
        {
            if (m_CurLineIdx_Night == 3)
            {
                SpeakerManager.instance.m_ZhenZi.m_CurLineIdx_Night = 1;
                this.StartAttack();
            }
            else
            {
                this.ShowText();
            }
        }
    }

    private void StartAttack()
    {
        this.ChangeState(MumState.Following);
    }

    public void ChangeState(MumState state)
    {
        m_CurState = state;
    }

    public void ChangeScene(Vector3 newPos, int newIdx)
    {
        m_Trans.position = newPos;
		m_CurSceneIdx = newIdx;
		StartCoroutine(IE_InvisibleAndShowAgain(2f));
    }

    private IEnumerator IE_InvisibleAndShowAgain(float t)
    {
        m_Visible = false;
        Collider2D col = GetComponent<Collider2D>();
        col.enabled = false;
        Renderer ren = GetComponentInChildren<Renderer>();
        if (ren != null)
        {
            ren.enabled = false;
        }

        yield return new WaitForSeconds(t);

        m_Visible = true;
        col.enabled = true;
        if (ren != null)
        {
            ren.enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Speaker spe = other.GetComponent<Speaker>();
        if (spe == null) return;

        // extension
        if (ExtensionManager.instance.m_OldWoman)
        {
            if (spe is CryingOldWoman)
            {
                this.SlowDown(spe);
            }
        }
        if (ExtensionManager.instance.m_Beauty)
        {
            if (spe is Beauty)
            {
                this.SlowDown(spe);
            }
            if (spe is Thin)
            {
                this.SlowDown(spe);
            }
        }

        if (spe is Conductor ||
        spe is Fatty ||
        spe is Handsome)
        {
            this.SlowDown(spe);
        }
    }

    private void SlowDown(Speaker spe)
    {
        spe.StopMoving();

        if (m_IE_SlowDown != null)
        {
            StopCoroutine(m_IE_SlowDown);
            m_IE_SlowDown = null;
        }
        m_IE_SlowDown = IE_ShowDown();
        StartCoroutine(m_IE_SlowDown);
    }

    private IEnumerator IE_ShowDown(float t = 1f)
    {
        m_CurVec = m_SlowDownVec;

        yield return new WaitForSeconds(t);

        m_CurVec = m_MoveVec;
    }

}