using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
	//animator to interact with the sprite
	private Animator anim;

	//varibles for movement
	private Rigidbody2D rb;
	public float speed = 5f;
	private Vector2 movement;

	// Start is called before the first frame update
	void Start()
	{
		//initliation of private varibles
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		//movment
		rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
	}

	void Update()
	{
		//input from the keyboard
		movement.x = Input.GetAxis("Horizontal");
		movement.y = Input.GetAxis("Vertical");

		//handles the sprites change in direction
		movmentDirection();

	}

	private void movmentDirection()
	{
		if (movement.x > 0)
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
			anim.SetBool("Side", true);
			anim.SetBool("Up", false);
			anim.SetBool("Down", false);
			anim.SetBool("isMoving", true);
		}
		else if (movement.x < 0)
		{
			transform.eulerAngles = new Vector3(0, 180, 0);
			anim.SetBool("Side", true);
			anim.SetBool("Up", false);
			anim.SetBool("Down", false);
			anim.SetBool("isMoving", true);
		}
		else if (movement.y > 0)
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
			anim.SetBool("Side", false);
			anim.SetBool("Up", true);
			anim.SetBool("Down", false);
			anim.SetBool("isMoving", true);
		}
		else if (movement.y < 0)
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
			anim.SetBool("Side", false);
			anim.SetBool("Up", false);
			anim.SetBool("Down", true);
			anim.SetBool("isMoving", true);
		}
		else
		{
			//transform.eulerAngles = new Vector3(0, 0, 0);
			anim.SetBool("Side", false);
			anim.SetBool("Up", false);
			anim.SetBool("Down", false);
			anim.SetBool("isMoving", false);
		}
	}
}
