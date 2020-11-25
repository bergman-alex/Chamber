using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
	private float speed;
	private Rigidbody2D rb;
	private Vector3 direction;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        direction = Random.insideUnitCircle.normalized; // random point on the unit circle
        GameMechanics mechs = GameObject.Find("GameMechanics").GetComponent<GameMechanics>();

        speed = 4f + Mathf.Log((float)mechs.roomCounter, 2) / 2f;
    }

    void Update()
    {
        rb.transform.position += direction * speed * Time.deltaTime;
        rb.transform.Rotate(0f, 0f, -5f, Space.Self);

        Vector3 p = transform.position;

        if (transform.position.x > 7.5f)
        {
        	p.x = 7.5f;
        	direction.x *= -1;
        }

        if (transform.position.x < -7.5f)
        {
        	p.x = -7.5f;
        	direction.x *= -1;
        }

        if (transform.position.y > 3.5f)
        {
        	p.y = 3.5f;
        	direction.y *= -1;
        }

        if (transform.position.y < -3.5f)
        {
        	p.y = -3.5f;
        	direction.y *= -1;
        }

        transform.position = p;
    }
}
