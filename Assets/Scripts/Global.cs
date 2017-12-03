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
    public Vector3 m_LeftBornPos = new Vector3(-14f, 0, 0);
    public Vector3 m_RightBornPos = new Vector3(47f, 0, 0);
    public Hero m_Hero;
    public Text m_SpeakText;
    public GameObject m_Btn_Yes;
    public GameObject m_Btn_No;
    public List<GameObject> m_Carts;
    public bool isNormal = true;
    public int m_CarIndex = 1;


    [HideInInspector]
    public List<StateChange> m_StateChanges;
    [HideInInspector]
    public List<Wolf> m_Wolfs;

    private SwitchType m_CurSwitch = SwitchType.NULL;
    private Speaker m_CurSpeaker = null;
    private bool m_IsSpeaking = false;

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
        AudioManager.instance.Play(Constants.BGM_Theme);
        SetCarActive(m_CarIndex);
    }
    public void ChangeSpeakText(string newText, Speaker speaker = null)
    {
        m_SpeakText.text = "";
        m_CurSpeaker = speaker;

        m_IsSpeaking = true;

        // DOTween.Restart(m_SpeakText);
        float dur = newText.Length * m_PerCharDur;
        m_SpeakText.DOText(newText, dur).
        SetEase(Ease.Linear).
        OnComplete(delegate ()
            {
                m_IsSpeaking = false;
                if (speaker != null)
                {
                    speaker.LineComplete();
                    // m_CurSpeaker = null;
                }

            });
    }
    public void CleanSpeakText()
    {
        DOTween.Pause(m_SpeakText);
        m_IsSpeaking = false;

        m_SpeakText.text = "";

        m_Btn_Yes.SetActive(false);
        m_Btn_No.SetActive(false);

        m_CurSwitch = SwitchType.NULL;
        m_CurSpeaker = null;
    }
    public void BtnCallback_SpeakTable()
    {
        // Debug.Log("BtnCallback_SpeakTable:\n" +
        //     DOTween.IsTweening(m_SpeakText) + "\n" + 
        //     m_CurSpeaker);
        if (m_CurSpeaker == null) return;
        if (m_IsSpeaking) return;
        // if (DOTween.IsTweening(m_SpeakText)) return;

        m_CurSpeaker.ShowText();
    }
    public void BtnCallback_Yes()
    {
        switch (m_CurSwitch)
        {
            case SwitchType.GoToPreScene:
                {
                    // Debug.Log("To pre scene!!!");
                    this.CleanSpeakText();

                    BornInPos(m_RightBornPos);
                    m_CarIndex--;
                    SetCarActive(m_CarIndex);

                    Mum mum = SpeakerManager.instance.m_Mum;
                    if (mum.m_CurState == MumState.Following)
                    {
                        mum.ChangeScene(m_RightBornPos, m_CarIndex);
                    }
                }
                break;

            case SwitchType.GoToNextScene:
                {
                    // Debug.Log("To next scene!!!");
                    this.CleanSpeakText();

                    BornInPos(m_LeftBornPos);
                    m_CarIndex++;
                    SetCarActive(m_CarIndex);
                }
                break;

            default:
                break;

        }
    }
    public void SetCarActive(int index)
    {
        for (int i = 0; i < m_Carts.Count; i++)
        {
            m_Carts[i].SetActive(false);
        }
        m_Carts[index - 1].SetActive(true);
    }
    public void BornInPos(Vector3 targetpos)
    {
        CameraEffect.instance.MaskScenes();
        m_Hero.transform.position = targetpos;
        CameraEffect.instance.transform.position = targetpos;
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
        AudioManager.instance.ChangeVol(Constants.BGM_Theme, 1f);
        AudioManager.instance.Stop(Constants.BGM_BeyondWorld);
        isNormal = true;
        CameraEffect.instance.MaskScenes();
        foreach (var one in m_StateChanges)
        {

            one.TurnToNormal();
        }
        foreach (var one in m_Wolfs)
        {
            one.StateChange(false, null);
        }

        this.CleanSpeakText();
    }

    public void BtnCallback_TurnWorld()
    {
        if (isNormal)
        {
            this.TurnToBeyondWorld();
        }
        else
        {
            this.TurnToNormalWorld();
        }
    }

    public void TurnToBeyondWorld()
    {
        if (isNormal == false)
        {
            return;
        }
        AudioManager.instance.ChangeVol(Constants.BGM_Theme, 0f);
        AudioManager.instance.Play(Constants.BGM_BeyondWorld);
        isNormal = false;
        CameraEffect.instance.MaskScenes();
        foreach (var one in m_StateChanges)
        {
            one.TurnToBeyond();
        }
        foreach (var one in m_Wolfs)
        {
            one.StateChange(true, m_Hero.transform);
        }

        this.CleanSpeakText();
    }

    public void TryGoToPreScene()
    {
        string text = "BE~~~~~~";

        if (m_CarIndex == 1)
        {
            this.ChangeSpeakText(text);
            return;
        }

        if (m_CarIndex == 4 &&
        SpeakerManager.instance.m_Mum.m_CurState != MumState.Following)
        {
            this.ChangeSpeakText(text);
            return;
        }

        text = "Goto the pre scene?";
        this.ChangeSpeakText(text);

        m_Btn_Yes.SetActive(true);
        m_Btn_No.SetActive(true);
        m_CurSwitch = SwitchType.GoToPreScene;
    }

    public void TryGoToNextScene()
    {
        string text = "BE~~~~~~";

        if (m_CarIndex == 4)
        {
            this.ChangeSpeakText(text);
            return;
        }

        if (!m_Hero.m_HoldPassCard)
        {
            this.ChangeSpeakText(text);
            return;
        }
        if (m_CarIndex == 3 &&
        SpeakerManager.instance.m_Handsome.m_CurLineIdx_Night != 5)
        {
            this.ChangeSpeakText(text);
            return;
        }

        text = "Goto the next scene?";
        this.ChangeSpeakText(text);

        m_Btn_Yes.SetActive(true);
        m_Btn_No.SetActive(true);
        m_CurSwitch = SwitchType.GoToNextScene;
    }

    public void GameOver()
    {
        Debug.LogError("Game Over");
    }

    public void FinalResult()
    {
        Debug.LogError("Final Result");
    }

    public void RemoveWolfs()
    {
        for (int i = m_Wolfs.Count - 1; i >= 0; i--)
        {
            Wolf one = m_Wolfs[i];
            m_Wolfs.RemoveAt(i);
            Destroy(one.gameObject);
        }
    }
}



