using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public float m_MoveVec = 5f;

    private Transform m_Trans;
    private Vector3 m_TarPos;

    void Awake()
    {
        m_Trans = transform;
        m_TarPos = m_Trans.position;
    }

    public void Move(Vector2 pos)
    {
        m_TarPos = new Vector3(pos.x, m_TarPos.y, 0);
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
        }
        else
        {
            Vector3 vec = (m_TarPos - m_Trans.position).normalized *
                m_MoveVec * Time.deltaTime;
            m_Trans.Translate(vec);
        }
    }
}
