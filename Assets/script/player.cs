using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {
	Rigidbody2D RG;//Rigidbody2D
	public float speed=0;//プレイヤーの移動速度
	Vector3 pos;//プレイヤー移動用のVector3
	Vector3 mousepos;//マウス座標
	float camerasize;
	public GameObject camera;
	Vector3 cpos;
	float distance;
    public GameObject item;
    public GameObject[] enemy;
    float posY;
    public bool END=false;
    public int battery = 5;//残り移動回数
    public GameObject start;
    public Slider battery_obj;

    void Start () {
		RG = GetComponent<Rigidbody2D> ();//Rigidbody2D
		camerasize = camera.GetComponent<Camera> ().orthographicSize;
        posY = transform.position.y;
        battery = 5;
        speed = 0;
        start.SetActive(false);
        END = false;
        battery_obj.maxValue = battery;
	}
	
	// Update is called once per frame
	void Update () {
        battery_obj.value = battery;

        if(END)
        {
            start.SetActive ( true);
        }
		
		RG.velocity =pos.normalized*speed;
		if (transform.position.x > camera.transform.position.x + (camerasize / 2) || transform.position.x < camera.transform.position.x - (camerasize / 2)||transform.position.y > camera.transform.position.y + camerasize || transform.position.y < camera.transform.position.y - camerasize) {
			speed = 0;
			RG.velocity = Vector3.zero;
            inst();
            if (battery == 0)
            {
                naichilab.RankingLoader.Instance.SendScoreAndShowRanking((int)transform.position.y*100);
                END = true;

            }
        }

		if (speed > 0) {
			speed -= 0.01f;
		} else if (Input.GetMouseButtonDown (0) && battery!=0) {
			mousepos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			pos.x = mousepos.x - transform.position.x;
			pos.y = mousepos.y - transform.position.y;
			pos.z = 0;
			speed = 3;
            battery--;
		}


		


		cpos = transform.position - camera.transform.position;//カメラとプレイヤーの座標の差
		cpos.z = 0;
		distance = cpos.magnitude;//カメラとプレイヤーの距離
	}

	void LateUpdate()
	{
		if (speed <= 0) {
			camera.transform.position += cpos.normalized*Mathf.Min(distance,0.1f);//カメラ移動
		}
	}

    void inst()
    {
        int instcount=0;
        if (posY < transform.position.y)
        {
            instcount = (int)(4.0f * (transform.position.y - posY) / 5.0f);//生成個数＝最大個数*今回の移動距離/最大の移動距離
            posY = transform.position.y;
        } 

         
        for (int i = 0; i < instcount; i++)
        {
            float rand_y = Random.Range(transform.position.y+1,transform.position.y+5);
            float rand_x = Random.Range(transform.position.x-2.5f , transform.position.x + 2.5f);
            
            int randenemy = Random.Range(0, enemy.Length);
            
            Vector3 instpos = new Vector3(rand_x, rand_y, 0);
            
            Instantiate(enemy[randenemy], instpos, transform.rotation);
        }

        float item_y = Random.Range(transform.position.y + 1, transform.position.y + 5);
        float item_x = Random.Range(transform.position.x - 2.5f, transform.position.x + 2.5f);

        Vector3 itempos = new Vector3(item_x, item_y, 0);
        if (Random.Range(0, 2) == 0)
        {
            Instantiate(item, itempos, transform.rotation);
        }
    }
}
