using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class regionBehaviour : MonoBehaviour {

    public GameObject[] asteroids;
    public GameObject newRegion;

    public int astNum;
    public int astType;
    public bool spawned;

    // Use this for initialization
    void Start ()
    {
        astType = Mathf.CeilToInt(Random.Range(0, 2));
        spawned = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && spawned == false)
        {
            spawned = true;
            for (int i = 0; i < astNum; i++)
            {
                if (astType == 0)
                {
                    Instantiate(asteroids[0], new Vector2(Random.Range(20, -20) + this.transform.position.x, Random.Range(20, -20) + this.transform.position.y), new Quaternion(Random.Range(100, -100), Random.Range(100, -100), 0, 0));
                    astType = Mathf.CeilToInt(Random.Range(0, 2));
                }
                if (astType >= 1)
                {
                    Instantiate(asteroids[1], new Vector2(Random.Range(20, -20) + this.transform.position.x, Random.Range(20, -20) + this.transform.position.y), new Quaternion(Random.Range(100, -100), Random.Range(100, -100), 0, 0));
                    astType = Mathf.CeilToInt(Random.Range(0, 2));
                }
            }


            if (other.gameObject.tag == "Region")
            {
                Destroy(other.gameObject);
            }
        }
    }
}
