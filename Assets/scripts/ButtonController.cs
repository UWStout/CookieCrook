using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
   public void onEasyPress()
	{
		SceneManager.LoadScene(1);
	}

	public void onMediumPress()
	{
		SceneManager.LoadScene(2);
	}

	public void onHardPress()
	{
		SceneManager.LoadScene(3);
	}

}
