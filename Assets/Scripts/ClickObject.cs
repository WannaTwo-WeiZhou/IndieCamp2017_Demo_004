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
        Debug.Log(gameObject.name + "be clicked!!! Type = " + m_ClickedType);

        switch (m_ClickedType)
        {
            case ClickedType.OnlyMove:
                {
					m_Hero.Move(pos);
                }
                break;

            case ClickedType.MoveToPreScene:
                {
					m_Hero.Move(pos);
                }
                break;

            case ClickedType.MoveToNextScene:
                {
					m_Hero.Move(pos);
                }
                break;

            case ClickedType.MoveAndSpeak:
                {
					m_Hero.Move(pos);
                }
                break;

            default:
                break;
        }
    }

}
