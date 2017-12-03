using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Speaker
{

    public float m_MoveVec = 3f;
    private bool canmove;
    private Transform m_Transform;
    private Transform m_TargetTransform;


    protected override void Awake()
    {
        base.Awake();

        m_Transform = transform;
        canmove = false;
		m_TargetTransform = null;
    }
    void Start()
    {
        Global.instance.m_Wolfs.Add(this);
    }

    // Update is called once per frame
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
        
        if (canmove)
        {
            MoveToTargetRole(m_TargetTransform.position);
        }
    }
    // update
    public void MoveToTargetRole(Vector3 targetpos)
    {
        if (Vector3.Distance(m_Transform.position, targetpos) <
           Time.deltaTime * m_MoveVec)
        {
            m_Transform.position = targetpos;


        }
        else
        {
            Vector3 vec = (targetpos - m_Transform.position).normalized *
               ( m_MoveVec * Time.deltaTime);
            m_Transform.Translate(vec);
        }
    }
    public void StateChange(bool iscanmove, Transform targetpos)
    {
        canmove = iscanmove;
        m_TargetTransform = targetpos;
    }
}
