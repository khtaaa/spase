using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	Rigidbody2D RG;
	float speed=0;
	Vector3 pos;
	Vector3 spos;
	void Start () {
		RG = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		RG.velocity =pos.normalized*speed;

		if (speed > 0) {
			speed -= 0.01f;
		} else if (Input.GetMouseButtonDown (0)) {
			spos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			pos.x = spos.x - transform.position.x;
			pos.y = spos.y - transform.position.y;
			pos.z = 0;
			speed = 3;
		}

		if (speed < 0) {
			speed = 0;
		}


	}
}
