using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public float m_MoveVec = 5f;

    // [HideInInspector]
    public bool m_HoldPassCard = false;
    public bool m_HoldPink = false;
    public bool m_HoldArm = false;

    private Transform m_Trans;
    private Vector3 m_TarPos;
    private ClickObject m_CurClickObj = null;

    private const string MOVETWEENID = "MoveTween";
	private const string PASSCARDTAG = "PassCard";
	private const string PINKTAG = "Pink";
	private const string ARMTAG = "Arm";
	private const string BELLTAG = "Bell";

    void Awake()
    {
        m_Trans = transform;
        m_TarPos = m_Trans.position;
        m_CurClickObj = null;
        m_HoldPassCard = false;
        m_HoldPink = false;
        m_HoldArm = false;
    }

    public void Move(Vector2 pos, ClickObject clickObj)
    {
        // DOTween.Pause(MOVETWEENID);

        // float dur = (Mathf.Abs(pos.x - m_Trans.position.x)) / m_MoveVec;
        // m_Trans.DOMoveX(pos.x, dur).SetId(MOVETWEENID).
        //     OnComplete(delegate ()
        //    {
        //        clickObj.ReachedPos();
        //    });
        // m_Trans.DOMoveX(pos.x, dur);

        m_TarPos = new Vector3(pos.x, m_TarPos.y, 0);
        m_CurClickObj = clickObj;
    }

    void Update()
    {
        // m_Trans.position = new Vector3(
        // 	Mathf.Lerp(
        // 		m_Trans.position.x, m_TarPos.x, m_MoveVec * Time.deltaTime), 
        // 	m_TarPos.y, 0
        // );
        if (Vector3.Distance(m_Trans.position, m_TarPos) <
            Time.deltaTime * m_MoveVec)
        {
            m_Trans.position = m_TarPos;

            if (m_CurClickObj != null)
            {
                m_CurClickObj.ReachedPos();
                m_CurClickObj = null;
            }
        }
        else
        {
            Vector3 vec = (m_TarPos - m_Trans.position).normalized *
                m_MoveVec * Time.deltaTime;
            m_Trans.Translate(vec);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(other.name);
        if (Global.instance.isNormal)
        {

        }
        else
        {
            if (other.GetComponent<Wolf>())
            {
                Global.instance.GameOver();
            }
            if (other.GetComponent<Mum>())
            {
                Global.instance.GameOver();
            }
        }

    }

    public void GetPassCard()
    {
        if (m_HoldPassCard) return;

        m_HoldPassCard = true;

        // show card
        GameObject passCard = GameObject.
            FindGameObjectWithTag(PASSCARDTAG);
        if (passCard != null)
        {
            Image img = passCard.GetComponent<Image>();
            img.DOFade(1f, 1f);
        }
    }
    public void GetPink()
    {
        if (m_HoldPink) return;

        m_HoldPink = true;

        // show pink
        GameObject pink = GameObject.
            FindGameObjectWithTag(PINKTAG);
        if (pink != null)
        {
            Image img = pink.GetComponent<Image>();
            img.DOFade(1f, 1f);
        }
    }
    public void GetArm()
    {
        if (m_HoldArm) return;

        m_HoldArm = true;

        // show arm
        GameObject arm = GameObject.
            FindGameObjectWithTag(ARMTAG);
        if (arm != null)
        {
            Image img = arm.GetComponent<Image>();
            img.DOFade(1f, 1f);
        }
    }

    public void GetBell()
    {
        GameObject bell = GameObject.
            FindGameObjectWithTag(BELLTAG);
        if (bell != null)
        {
            Image img = bell.GetComponent<Image>();
            img.DOFade(1f, 1f);
            Button btn = bell.GetComponent<Button>();
            btn.enabled = true;
        }
    }
    public void LoseBell()
    {
        GameObject bell = GameObject.
            FindGameObjectWithTag(BELLTAG);
        if (bell != null)
        {
            Image img = bell.GetComponent<Image>();
            img.DOFade(0f, 1f);
            Button btn = bell.GetComponent<Button>();
            btn.enabled = false;
        }
    }
}

