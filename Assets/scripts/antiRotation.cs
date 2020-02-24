using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antiRotation : MonoBehaviour
{
	public Transform parent;
	public Animator anim;
	float degrees;

	// Update is called once per frame
	void Update()
	{ 
		transform.eulerAngles = new Vector3(0,0, 0);
		movmentDirection();
   }

	private void movmentDirection()
	{
		if ( (parent.eulerAngles.z > -45 && parent.eulerAngles.z < 45) || parent.eulerAngles.z < -315 || parent.eulerAngles.z > 315)
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
			anim.SetBool("side", false);
			anim.SetBool("up", false);
			anim.SetBool("back", true);
		}
		else if ((parent.eulerAngles.z > 45 && parent.eulerAngles.z < 135) || (parent.eulerAngles.z > -315 && parent.eulerAngles.z < -225))
		{
			transform.eulerAngles = new Vector3(0, 180, 0);
			anim.SetBool("side", true);
			anim.SetBool("up", false);
			anim.SetBool("back", false);
		}
		else if ((parent.eulerAngles.z > 135 && parent.eulerAngles.z < 225) || (parent.eulerAngles.z > -225 && parent.eulerAngles.z < -135))
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
			anim.SetBool("side", false);
			anim.SetBool("up", true);
			anim.SetBool("back", false);
		}
		else if ((parent.eulerAngles.z > 225 && parent.eulerAngles.z < 315) || (parent.eulerAngles.z > -135 && parent.eulerAngles.z < -45))
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
			anim.SetBool("side", true);
			anim.SetBool("up", false);
			anim.SetBool("back", false);
		}
	}
}
