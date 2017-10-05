using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour {

    
    public GameObject projectile;
    public GameObject[] hardPoints;

    public float speed;
    public float turnSpeed;

    private GameObject target;
    private Rigidbody2D rb;

    private float shootTime;
    private int health;
    private int deflect;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        health = 10;
        deflect = Mathf.CeilToInt(Random.Range(0, 2));
        turnSpeed = 3f;
        speed = 1;
        shootTime = 1;

        target = findEnemy();
    }
	
	// Update is called once per frame
	void Update () {

        if (target)
        {
            aiController();
            StartCoroutine(updateTarget());
        }
        else
            StartCoroutine(updateTarget());

        if (shootTime <= 1)
        {
            shootTime += Time.deltaTime;
        }

		if (health <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    private void FixedUpdate()
    {
        if (target != null)
        {
            rb.AddRelativeForce(Vector3.up * speed, ForceMode2D.Force);
        }
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "AllyProjectile")
        {
            if (deflect == 0)
            {
                deflect = Mathf.CeilToInt(Random.Range(0, 2));
                health--;
                Destroy(c.gameObject);
            }
            else
                deflect = Mathf.CeilToInt(Random.Range(0, 2));
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && other.gameObject.transform.position.x < transform.position.x)
        {
            transform.rotation *= Quaternion.Euler(0, 0, -0.5f);
        }
        else if (other.gameObject.tag == "Enemy" && other.gameObject.transform.position.x > transform.position.x)
        {
            transform.rotation *= Quaternion.Euler(0, 0, 0.5f);
        }
    }

    public void aiController()
    {
        Vector3 targetDir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
        //float currentAngle = transform.rotation.z;
        Quaternion smoothRot = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        //Vector3 newDir = Vector2.(transform.forward, targetDir, step, 0.0f);
        transform.rotation = Quaternion.Slerp(transform.rotation , smoothRot, turnSpeed / (rb.velocity.magnitude + 0.7f) * Time.deltaTime);

        if (shootTime >= 1 && targetDir.sqrMagnitude <= 0.4f && Vector2.Distance(transform.position, target.transform.position) < 10)
        {
            for (int i = 0; i < hardPoints.Length; i ++)
            {
                Instantiate(projectile, hardPoints[i].transform.position, hardPoints[i].transform.rotation);
                shootTime = 0;
            }
        }
    }

    GameObject findEnemy()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Ally");
        GameObject closest = null;
        float dist = Mathf.Infinity;

        foreach (GameObject go in gos)
        {
            float diff = Vector3.Distance(go.transform.position, transform.position);
            if (diff < dist)
            {
                closest = go;
                dist = diff;
            }
        }
        return closest;
    }

    IEnumerator updateTarget()
    {
        target = findEnemy();
        yield return new WaitForSeconds(Random.Range(0, 5));
        StartCoroutine(updateTarget());
    }
}
