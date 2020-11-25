using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
	private float rotationSpeed;
	private float fireDelay;
	private float fireCycle;
    private Rigidbody2D rb;

    [SerializeField] private GameObject arrowPrefab = null;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        GameMechanics mechs = GameObject.Find("GameMechanics").GetComponent<GameMechanics>();

        if (Random.value > 0.5f)
        {
            rotationSpeed = Random.Range(1.5f, 10f);
        }
        else
        {
            rotationSpeed = Random.Range(-10f, -1.5f);
        }

        fireDelay = 1f;
        fireCycle = 0.4f - 8 * Mathf.Log((float)mechs.roomCounter, 2) / 150f;

        InvokeRepeating("shootArrow", fireDelay, fireCycle);
    }

    void Update()
    {
        rb.transform.Rotate(0, 0, rotationSpeed);
    }

    void shootArrow()
    {
    	GameObject arrow = Instantiate(arrowPrefab, rb.transform.position, rb.transform.rotation * Quaternion.Euler(0,0,180f)) as GameObject;
    	arrow.transform.position = rb.transform.position;
    }
}
