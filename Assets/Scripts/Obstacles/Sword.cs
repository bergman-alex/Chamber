using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
	private Rigidbody2D rb;
	private GameMechanics mechs;
	private float startSpeed = 0.25f;
	private int randomDirection;

	void Start()
	{
		rb = this.GetComponent<Rigidbody2D>();
        mechs = GameObject.Find("GameMechanics").GetComponent<GameMechanics>();
        randomDirection = Random.Range(0, 2) * 2 - 1; // 1 or -1 at random
	}

    void Update()
    {
        rb.transform.Rotate(0f, 0f, (startSpeed + Mathf.Log((float)mechs.roomCounter, 2) / 20f) * randomDirection, Space.Self); 
    }
}
