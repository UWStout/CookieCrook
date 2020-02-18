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
	public Text lifeText;

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
		InvokeRepeating("clock", 1, 1);//call of time keeping fuction
	}

	private void Update()
	{
		UITextUpdate();
	}

	//time keeping function
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

	//text update functions
	private void UITextUpdate()
	{
		if(score == 0f)
		{
			scoreText.text = "00000";
		}
		else if(score < 1000)
		{
			scoreText.text = "00" + score.ToString();
		}
		else if(score < 10000)
		{
			scoreText.text = "0" + score.ToString();
		}
		else
		{
			scoreText.text = score.ToString();
		}

		counterText.text = "Cookies: " + cookieCount.ToString();

		lifeText.text = "Lives: " + lives.ToString();
	}

	//public fnctions called by other scripts
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

	//getters
	public int getTime()
	{
		return time;
	}

	public int getScore()
	{
		return score;
	}
}
