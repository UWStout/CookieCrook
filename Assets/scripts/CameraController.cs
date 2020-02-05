using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	Transform player;

	Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	 }

    // Update is called once per frame
    void Update()
    {
		target = player.position;
		target.z = -10;

		transform.position = target;
    }
}
