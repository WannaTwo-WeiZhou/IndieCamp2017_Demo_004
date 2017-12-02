using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public Ray m_Ray;

    // Update is called once per frame  
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.
            ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(
                new Vector2(myRay.origin.x, myRay.origin.y),
                Vector2.down);
            if (hits.Length > 0)
            {
				int highestIdx = 0;
				ClickedType highestType = ClickedType.NULL;
				for (int i = 0; i < hits.Length; i++)
				{
					ClickObject oneClick = hits[i].collider.
						GetComponent<ClickObject>();
					if (oneClick.m_ClickedType > highestType)
					{
						highestIdx = i;
						highestType = oneClick.m_ClickedType;
					}
				}
                ClickObject clickCO =
                    hits[highestIdx].collider.GetComponent<ClickObject>();
                if (clickCO != null)
                {
                    clickCO.BeClicked(hits[highestIdx].point);
                }
            }


        }
    }
}