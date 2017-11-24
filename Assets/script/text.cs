using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour {
	Text TT;
	public GameObject player;

	// Use this for initialization
	void Start () {
		TT = this.gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		TT.text = "" + (int)player.transform.position.y*100;
	}
}
