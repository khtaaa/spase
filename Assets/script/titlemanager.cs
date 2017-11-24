using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titlemanager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && !Fade_Out.fade_ok) {
            Fade_Out.next = "game";
            Fade_Out.fade_ok = true;
		}
	}
}
