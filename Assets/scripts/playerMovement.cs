using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
	Animator anim;

	Rigidbody2D rb;
	public float speed = 5f;
	Vector2 movement;

	// Start is called before the first frame update
	void Start()
	{
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
		//input
		movement.x = Input.GetAxis("Horizontal");
		movement.y = Input.GetAxis("Vertical");

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
