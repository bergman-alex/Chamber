using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
	[SerializeField] private float speed = 0f;

	private Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    	rb.transform.position += -transform.up * speed * Time.deltaTime;

        if (transform.position.x > 8f || transform.position.x < -8f || transform.position.y > 4f || transform.position.y < -4f)
        {
        	Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    	if (other.tag == "Player"){
    		Destroy(this.gameObject);
    	}
    }
}
