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

	//UI end score overlay
	public GameObject endOverlay;

	public int startingTime;
	public int scorePerCookie;
	public int lives;

	private int cookieCount;
	private int time;
	private int score;
	private Transform entrance;

	// Start is called before the first frame update
	void Start()
    {
		cookieCount = 0;
		score = 0;
		entrance = GameObject.FindGameObjectWithTag("Entrance").transform;
		transform.position = entrance.position;
		time = startingTime;
		timeText.text = startingTime.ToString();
		counterText.text = "Cookies: 0";
		scoreText.text = "00000";
		InvokeRepeating("clock", 1, 1);
	}

	private void Update()
	{
		scoreText.text = scoreUpdate();
		counterText.text = countUpdate();
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
			cookieCount++;
			score += scorePerCookie;
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

	private string countUpdate()
	{
		return "Cookies: " + cookieCount.ToString();
	}

	public void death()
	{
		lives--;
		if(lives <= 0)
		{
			endOverlay.SetActive(true);
			Time.timeScale = 0;
		}
		cookieCount = 0;
		transform.position = entrance.position;
	}

	public void dropOff()
	{
		score += (cookieCount * 100);
		cookieCount = 0;
	}
}
