using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade_Out : MonoBehaviour {
	public float speed = 0.01f;
	public float alfa;
	float red,green,blue;
	public static bool fade_ok;
	public static string next;

	// Use this for initialization
	void Start () {
		red = GetComponent<Image> ().color.r;
		green = GetComponent<Image> ().color.g;
		blue = GetComponent<Image> ().color.b;
		alfa = 0;
		fade_ok = false;
		next = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (fade_ok) {
			alfa += speed;
			GetComponent<Image> ().color = new Color (red, green, blue, alfa);
			if (alfa > 1) {
				fade_ok = false;
				SceneManager.LoadScene (next);
			}
		}
	}
}
