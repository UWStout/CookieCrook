using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
	Rigidbody2D rb;
	public float speed = 5f;
	Vector2 movement;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
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

	}
}
