using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public float m_MoveVec = 5f;

    private Transform m_Trans;
    private Vector3 m_TarPos;
    private ClickObject m_CurClickObj = null;

    private const string MOVETWEENID = "MoveTween";

    void Awake()
    {
        m_Trans = transform;
        m_TarPos = m_Trans.position;
        m_CurClickObj = null;
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
        Debug.Log(other.name);
        if (Global.instance.isNormal)
        {

        }
        else
        {
            if (other.GetComponent<Wolf>() == true)
            {
                Global.instance.GameOver();
            }
        }

    }
}

