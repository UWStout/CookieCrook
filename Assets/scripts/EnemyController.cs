using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour
{
	public Transform target;

	private AIDestinationSetter destination;

	private AIPath path;

    // Start is called before the first frame update
    void Start()
    {
		destination = GetComponent<AIDestinationSetter>();
		path = GetComponent<AIPath>();
	}

    // Update is called once per frame
    void Update()
    {
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
}
