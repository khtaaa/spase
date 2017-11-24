using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking((int)player.transform.position.y*100);
            player.GetComponent<player>().speed = 0;
            player.GetComponent<player>().battery = 0;
            player.GetComponent<player>().END = true;
        }
    }
}
