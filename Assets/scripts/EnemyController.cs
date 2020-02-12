﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour
{
	public Transform target;
	public float fov = 110f;

	private GameObject player;
	private AIDestinationSetter destination;

	private AIPath path;

    // Start is called before the first frame update
    void Start()
    {
		destination = GetComponent<AIDestinationSetter>();
		path = GetComponent<AIPath>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

    // Update is called once per frame
    void Update()
    {
		Debug.DrawRay(transform.position, transform.right + (transform.up * 0.9f), Color.red);
		Debug.DrawRay(transform.position, -transform.right + (transform.up * 0.9f), Color.red);

		if (path.reachedDestination)
		{
			Debug.Log("reached destination");
			//random path generation in a given area
			target.position = new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-8.0f, 8.0f), 0.0f);
		}
		else
		{
			destination.target = target;
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		Vector2 direct = collision.transform.position - transform.position;
		float angle = Vector2.Angle(transform.up, direct);

		if(collision.CompareTag("Player") && angle < fov * 0.5f)
		{
			//Debug.Log("player is in sight");
			player.GetComponent<playerController>().lives--;
			player.GetComponent<playerController>().death();
		}
	}
}
