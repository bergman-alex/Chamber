using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{	
	[SerializeField] private float moveSpeed = 0;
    [SerializeField] private Image lifeImg = null;
    [SerializeField] private GameObject floatingText = null;

    public CameraShake cameraShake;

	private int life;
	private Animator anim;
	private float timer;
    private int maxLife;
    private Vector3 baseScale;
    private bool invulnerable;

    void Start()
    {
    	maxLife = 90;
    	invulnerable = false;	
        anim = GetComponent<Animator>();
        life = maxLife;
        timer = 0f;
        baseScale = transform.localScale;
    }

    void Update()
    {
    	// LIFE
    	lifeImg.fillAmount = (float)life / (float)maxLife;

    	if (life < 0)
    	{
    		StartCoroutine(Die());
    	}

    	if (timer > 1f && life < maxLife)	// every second, if life is below maximum
        {
        	life += 1;					// regen one life per three rooms
        	timer = 0f;					// reset the timer
        }

        timer += Time.deltaTime;

    	// MOVEMENT
    	float horizontalMovement = Input.GetAxisRaw("Horizontal");
    	float verticalMovement = Input.GetAxisRaw("Vertical");
    	Vector3 inputVector = new Vector3(horizontalMovement, verticalMovement, 0f);
    	inputVector.Normalize();
    	transform.Translate(inputVector * moveSpeed * Time.deltaTime);

    	Vector3 p = transform.position;

        Facing(horizontalMovement); // check for facing
    	
    	anim.SetFloat("MoveX", horizontalMovement);
    	anim.SetFloat("MoveY", verticalMovement);

		// WALL CONSTRAINTS
		if (p.x > 7.5f)
    	{	
    		p.x = 7.5f;
    		transform.position = p;
    	} 
        
    	if (p.x < -7.5f)
    	{	
    		p.x = -7.5f;
    		transform.position = p;
    	}

    	if (p.y > 3.5f)
    	{	
    		p.y = 3.5f;
    		transform.position = p;
    	}

    	if (p.y < -3.5f)
    	{	
    		p.y = -3.5f;
    		transform.position = p;
    	}
    }

    IEnumerator Die()
    {
    	yield return new WaitForSeconds(0.25f); // let hit sound and screen shake finish
    	SceneManager.LoadScene(2); // load game over screen

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    	if (other.tag == "Obstacle" && invulnerable == false) // if hit
    	{
    		life -= 30; // remove one bar of life
    		SoundManager.PlaySound("playerHit"); // play hit sound
            Instantiate(floatingText, transform.position, Quaternion.identity); // display text
            StartCoroutine(cameraShake.Shake(0.1f, 0.25f)); // shake camera
            invulnerable = true; 
         	Invoke("resetInvulnerability", 1); // become invulnerable for one second
    	}
    }

    private void resetInvulnerability()
    {
    	invulnerable = false;
    }

    private void Facing(float move)
    {
        if(move > 0.5) // if moving right
        {
            transform.localScale = baseScale; // face right
        }
        else if(move < -0.5) // if moving left
        {
            transform.localScale = Vector3.Scale(baseScale, new Vector3(-1, 1, 1)); // face left
        }
    }
}