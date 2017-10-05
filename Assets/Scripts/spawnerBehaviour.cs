using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerBehaviour : MonoBehaviour {

    public GameObject ship;
    public GameObject[] ships;

    public int shipNumb;

    private float timer;
    private float time;

	// Use this for initialization
	void Start () {
        timer = Random.Range(3, 10);
        
	}
	
	// Update is called once per frame
	void Update () {
        if (ship.tag == "Ally")
            ships = GameObject.FindGameObjectsWithTag("Ally");

        if (ship.tag == "Enemy")
            ships = GameObject.FindGameObjectsWithTag("Enemy");

        if (time < timer)
            time += Time.deltaTime;
        else
        {
            if (ships.Length < shipNumb)
            {
                Instantiate(ship, transform.position, transform.rotation);
                timer = Random.Range(3, 10);
            }
        }
	}
}
