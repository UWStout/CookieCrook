using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour
{
	public Transform target;
	public Transform other;
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
		Debug.DrawRay(transform.position, transform.right + (transform.up), Color.red);
		Debug.DrawRay(transform.position, -transform.right + (transform.up), Color.red);

		if (path.reachedDestination)
		{
			Debug.Log("reached destination");

			//random path generation in a given area
			//target.position = new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-8.0f, 8.0f), 0.0f);

			//destination switch from other to target and back
			switchTarget();
		}
		else
		{
			//leaves the destination the same
			destination.target = target;
		}
	}

	// handles all the death logic
	private void OnTriggerStay2D(Collider2D collision)
	{
		//calculates the angle of the player from the direction the enemy is facing for FOV checks
		Vector2 direct = collision.transform.position - transform.position;
		float angle = Vector2.Angle(transform.up, direct);

		//checks if the player is close enough and in the FOV of the enemy
		if (collision.CompareTag("Player") && angle < fov * 0.5f)
		{
			//calculates line of sight
			RaycastHit2D hit = Physics2D.Raycast(transform.position, direct);
			Debug.Log(hit.transform.name);

			//checks if the enemy has line of sight on the player
			if (hit.transform.name == "Player")
			{
				//calls player death fuction
				player.GetComponent<playerController>().death();
			}
		}
	}

	private void switchTarget()
	{
		Vector3 temp;
		temp = target.position;
		target.position = other.position;
		other.position = temp;
	}
}
