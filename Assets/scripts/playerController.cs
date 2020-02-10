using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
	//text UI elements
	public Text counterText;
	public Text scoreText;
	public Text timeText;

	private int count;
	private float time;
	private int score;

	// Start is called before the first frame update
	void Start()
    {
		count = 0;
		time = 300;
		timeText.text = "300";
		counterText.text = "Cookies: 0";
		scoreText.text = "00000";
		InvokeRepeating("clock", 1, 1);
	}

	private void Update()
	{
		scoreText.text = scoreUpdate();
	}

	private void clock()
	{
		time--;
		timeText.text = time.ToString();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			count++;
			score += 100;
			counterText.text = "Cookies: " + count.ToString();
		}
	}

	private string scoreUpdate()
	{
		if(score == 0f)
		{
			return "00000";
		}
		else if(score < 1000)
		{
			return "00" + score.ToString();
		}
		else if(score < 10000)
		{
			return "0" + score.ToString();
		}
		else
		{
			return score.ToString();
		}
	}
}
