using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehaviour : MonoBehaviour {

    private Camera cam;
    private Transform trans;
    private GameObject player;
    private Vector2 playerPos;
    private Vector2 camPosition;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        trans = this.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player)
        {
            playerPos = player.GetComponent<Transform>().position;
            trans.position = new Vector3(playerPos.x, playerPos.y, -10 + player.GetComponent<playerBehaviour>().rb.velocity.magnitude * 2f);
        }
	}
}
