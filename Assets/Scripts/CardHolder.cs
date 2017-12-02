using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CardHolder : Speaker
{
    public GameObject m_PassCard;

    private const string PASSCARDTAG = "PassCard";

    protected override void Awake()
    {
        base.Awake();

        m_PassCard = GameObject.FindGameObjectWithTag(PASSCARDTAG);
    }

    protected override void AdditionalAction()
    {
        if (Global.instance.m_KeyIdx == 1 && Global.instance.isNormal)
        {
            this.ShowPassCard();

            Global.instance.m_Hero.m_HoldPassCard = true;

            m_Texts_Day = "拿去吧勇士";
        }

    }

    private void ShowPassCard()
    {
        if (m_PassCard == null) return;

        Image img = m_PassCard.GetComponent<Image>();
        img.DOFade(1f, 1f);
    }
}
