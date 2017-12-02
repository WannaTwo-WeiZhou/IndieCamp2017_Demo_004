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
					
                }
                break;

            case ClickedType.MoveToNextScene:
                {
					
                }
                break;

            case ClickedType.MoveAndSpeak:
                {
					Speak speak = GetComponent<Speak>();
					if (speak != null)
					{
						speak.ShowText();
					}
                }
                break;

            default:
                break;
        }
	}

}
