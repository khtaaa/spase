using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {
    public void title()
    {
        if (!Fade_Out.fade_ok)
        {
            Fade_Out.next = "title";
            Fade_Out.fade_ok = true;
        }
    }
}
