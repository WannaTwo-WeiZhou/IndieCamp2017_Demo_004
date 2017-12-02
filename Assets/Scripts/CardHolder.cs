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
        if (Global.instance.isNormal)
        {
            this.ShowPassCard();

            Global.instance.m_Hero.m_HoldPassCard = true;
        }

    }

    private void ShowPassCard()
    {
        if (m_PassCard == null) return;

        Image img = m_PassCard.GetComponent<Image>();
        img.DOFade(1f, 1f);
    }
}
