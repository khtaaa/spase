using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour {
    GameObject player;

    void Start()
    {
        
        player = GameObject.Find("player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            player.GetComponent<player>().battery +=3;
            if (player.GetComponent<player>().battery > 5)
                player.GetComponent<player>().battery = 5;
            Destroy(gameObject);
        }
        

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("enemy"))
        {
            Debug.Log("inst");
            float item_y = Random.Range(transform.position.y + 1, transform.position.y + 5);
            float item_x = Random.Range(transform.position.x - 2.5f, transform.position.x + 2.5f);

            Vector3 itempos = new Vector3(item_x, item_y, 0);

            Instantiate(this.gameObject, itempos, transform.rotation);
            Destroy(gameObject);
        }
    }
}
