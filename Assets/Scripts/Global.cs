using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
    private enum SwitchType
    {
        NULL = -1,

        GoToPreScene = 0,
        GoToNextScene = 1,

        SIZE
    };

    public static Global instance { get; private set; }

    public float m_PerCharDur = 0.2f;

    public Hero m_Hero;
    public Text m_SpeakText;
    public GameObject m_Btn_Yes;
    public GameObject m_Btn_No;
    [HideInInspector]
    public List<StateChange> m_StateChanges;
    [HideInInspector]
    public List<Wolf> m_Wolfs;
    public bool isNormal = true;

    private SwitchType m_CurSwitch = SwitchType.NULL;

    void OnEnable()
    {
        if (Global.instance == null)
        {
            Global.instance = this;
        }
        else if (Global.instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        isNormal = true;
    }
    public void ChangeSpeakText(string newText)
    {
        m_SpeakText.text = "";

        // DOTween.Restart(m_SpeakText);
        float dur = newText.Length * m_PerCharDur;
        m_SpeakText.DOText(newText, dur);
    }
    public void CleanSpeakText()
    {
        DOTween.Pause(m_SpeakText);

        m_SpeakText.text = "";

        m_Btn_Yes.SetActive(false);
        m_Btn_No.SetActive(false);

        m_CurSwitch = SwitchType.NULL;
    }
    public void BtnCallback_Yes()
    {
        switch (m_CurSwitch)
        {
            case SwitchType.GoToPreScene:
                {
                    Debug.Log("To pre scene!!!");
                }
                break;

            case SwitchType.GoToNextScene:
                {
                    Debug.Log("To next scene!!!");
                }
                break;

            default:
                break;

        }
    }
    public void BtnCallback_No()
    {
        switch (m_CurSwitch)
        {
            case SwitchType.GoToPreScene:
                {
                    this.CleanSpeakText();
                }
                break;

            case SwitchType.GoToNextScene:
                {
                    this.CleanSpeakText();
                }
                break;

            default:
                break;

        }
    }

    public void TurnToNormalWorld()
    {
        if (isNormal)
        {
            return;
        }
        isNormal = true;
        CameraEffect.instance.MaskScenes();
        foreach (var one in m_StateChanges)
        {

            one.TurnToNormal();
        }
		foreach(var one in m_Wolfs)
		{
			one.StateChange(false,null);
		}

        this.CleanSpeakText();
    }
    public void TurnToBeyondWorld()
    {
        if (isNormal == false)
        {
            return;
        }
        isNormal = false;
        CameraEffect.instance.MaskScenes();
        foreach (var one in m_StateChanges)
        {
            one.TurnToBeyond();
        }
		foreach(var one in m_Wolfs)
		{
			one.StateChange(true,m_Hero.transform);
		}

        this.CleanSpeakText();
    }

    public void TryGoToPreScene()
    {
        string text = "Goto the pre scene?";
        this.ChangeSpeakText(text);

        m_Btn_Yes.SetActive(true);
        m_Btn_No.SetActive(true);
        m_CurSwitch = SwitchType.GoToPreScene;
    }

    public void TryGoToNextScene()
    {
        if (m_Hero.m_HoldPassCard)
        {
            string text = "Goto the next scene?";
            this.ChangeSpeakText(text);

            m_Btn_Yes.SetActive(true);
            m_Btn_No.SetActive(true);
            m_CurSwitch = SwitchType.GoToNextScene;
        }
        else
        {
            string text = "BE~~~~~~";
            this.ChangeSpeakText(text);
        }

    }

    public void GameOver()
    {
		Debug.LogError("Game Over");
    }
}



