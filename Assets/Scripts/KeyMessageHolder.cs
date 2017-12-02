using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMessageHolder : Speaker
{

    protected override void AdditionalAction()
    {
        if (Global.instance.m_KeyIdx == 0 && !Global.instance.isNormal)
        {
            Global.instance.m_KeyIdx = 1;
        }

    }

}
