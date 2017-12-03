using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    NULL = -1,

    Arm = 0,

    SIZE
};

public class Item : MonoBehaviour
{
	public int m_CarIdx = 1;
	public bool m_Visible = true;
    public ItemType m_Type = ItemType.NULL;
    protected virtual void Update()
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
    }

	protected void SetVisible(bool val)
	{
		m_Visible = val;

		Collider2D col = GetComponent<Collider2D>();
        col.enabled = val;
        Renderer ren = GetComponentInChildren<Renderer>();
        if (ren != null)
        {
            ren.enabled = val;
        }
	}

    public void GetItem()
    {
        switch (m_Type)
        {
            case ItemType.Arm:
                {
                    Global.instance.m_Hero.GetArm();
                }
                break;

            default:
                break;
        }
    }

}
