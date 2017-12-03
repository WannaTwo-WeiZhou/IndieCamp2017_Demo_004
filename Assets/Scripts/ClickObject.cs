using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClickedType
{
    NULL = -1,

    OnlyMove = 0,
    MoveToPreScene = 1,
    MoveToNextScene = 2,
    MoveAndSpeak = 3,
    GetSomething = 4,

    SIZE

};

public class ClickObject : MonoBehaviour
{
    public ClickedType m_ClickedType = ClickedType.NULL;

	private Hero m_Hero;

	void Awake()
	{
		m_Hero = Global.instance.m_Hero;
	}

    public void BeClicked(Vector2 pos)
    {
        // Debug.Log(gameObject.name + "be clicked!!! Type = " + m_ClickedType);

        m_Hero.Move(pos, this);

        if (SpeakerManager.instance.m_Mum.m_CurState != MumState.Speaking)
            Global.instance.CleanSpeakText();
    }

	public void ReachedPos()
	{
        // Debug.Log(gameObject.name + " reached!!! Type = " + m_ClickedType);

		switch (m_ClickedType)
        {
            case ClickedType.OnlyMove:
                {
					// do nothing
                }
                break;

            case ClickedType.MoveToPreScene:
                {
					Global.instance.TryGoToPreScene();
                }
                break;

            case ClickedType.MoveToNextScene:
                {
					Global.instance.TryGoToNextScene();
                }
                break;

            case ClickedType.MoveAndSpeak:
                {
					Speaker speak = GetComponent<Speaker>();
					if (speak != null)
					{
						speak.ShowText();
					}
                }
                break;

            case ClickedType.GetSomething:
                {
					Item it = GetComponent<Item>();
					if (it != null)
					{
						it.GetItem();
					}
                }
                break;

            default:
                break;
        }
	}

}
