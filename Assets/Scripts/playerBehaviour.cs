using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerBehaviour : MonoBehaviour {

    public GameObject[] hardPoints;
    public GameObject projectile;
    public Text healthText;

    public int acc;
    public int health;
    public float turnSpeed;

    private float vel;
    private int deflect;

    public Rigidbody2D rb;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
        acc = 2;
        deflect = Mathf.CeilToInt(Random.Range(0, 2));
        turnSpeed = 3;
        health = 10;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * turnSpeed / (rb.velocity.magnitude + 0.7f));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * turnSpeed / (rb.velocity.magnitude + 0.7f));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i =0; i < hardPoints.Length; i++)
            {
                Instantiate(projectile, hardPoints[i].transform.position, hardPoints[i].transform.rotation);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject.Find("GameManager").GetComponent<gameManager>().pauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }

        healthText.text = "Health: " + health;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.up * acc, ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(-Vector3.up * acc, ForceMode2D.Force);
        }

        vel = rb.velocity.magnitude;
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "EnemyProjectile")
        {
            deflect = Mathf.CeilToInt(Random.Range(0, 2));
            health--;
            Destroy(c.gameObject);
        }
        else
            deflect = Mathf.CeilToInt(Random.Range(0, 2));
    }
}
