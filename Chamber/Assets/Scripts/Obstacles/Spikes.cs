using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
	private Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    	Vector3 p = transform.position;

    	// WALL CONSTRAINTS
        if (p.x > 6.75f)
    	{	
    		p.x = 6.75f;
    		transform.position = p;
    	} 
        
    	if (p.x < -6.75f)
    	{	
    		p.x = -6.75f;
    		transform.position = p;
    	}

    	if (p.y > 2.75f)
    	{	
    		p.y = 2.75f;
    		transform.position = p;
    	}

    	if (p.y < -2.75f)
    	{	
    		p.y = -2.75f;
    		transform.position = p;
    	}
    }

    private void DestroySpikes() // called at end of animation
    {
    	Destroy(this.gameObject);
    }
}
