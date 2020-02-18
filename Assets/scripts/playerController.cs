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

	public Text notice;
	private float noticeOppacity;

	//UI end score overlay
	public GameObject endOverlay;

	//total number of cookies in the level
	public int maxCookies;

	public int startingTime;
	public int scorePerCookie;
	public int lives;

	private int totalCookies;
	private int cookieCount;
	private int time;
	private int score;
	private Transform entrance;

	// Start is called before the first frame update
	void Start()
    {
		cookieCount = 0;
		score = 0;
		noticeOppacity = 0;
		entrance = GameObject.FindGameObjectWithTag("Entrance").transform;
		transform.position = entrance.position;
		time = startingTime;
		timeText.text = startingTime.ToString();
		counterText.text = "Cookies: 0";
		scoreText.text = "00000";
		InvokeRepeating("clock", 1, 1);//call of time keeping fuction
		notice.color = new Color(1, 1, 0, noticeOppacity);
	}

	private void Update()
	{
		UITextUpdate();
		notice.color = new Color(1, 1, 0, noticeOppacity);
		noticeOppacity -= 0.009f;
	}

	//time keeping function
	private void clock()
	{
		time--;
		timeText.text = time.ToString();
		if (time <= 0)
		{
			notice.text = "Out Of Time";
			noticeOppacity = 1;
			endOverlay.SetActive(true);
			Time.timeScale = 0;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			cookieCount++;
			score += scorePerCookie;
		}

		//at the entrance for dropping of cookies
		if (other.gameObject.CompareTag("Entrance"))
		{
			if (cookieCount > 0)
			{
				score += (cookieCount * scorePerCookie);
				totalCookies += cookieCount;
				cookieCount = 0;
				notice.text = "Cookies Stashed";
				noticeOppacity = 1;
			}
			//checks of all cookies have been collected
			if (totalCookies == maxCookies)
			{
				notice.text = "Cookies Stashed and All Cookies Found";
				noticeOppacity = 1;
				totalCookies = 0;
				endOverlay.SetActive(true);
				Time.timeScale = 0;
			}
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
			notice.text = "Out of Lives";
			endOverlay.SetActive(true);
			Time.timeScale = 0;
		}
		else
		{
			notice.text = "You Were Seen";
		}
		noticeOppacity = 1;
		totalCookies += cookieCount;
		cookieCount = 0;
		transform.position = entrance.position;
		//checks of all cookies have been collected
		if (totalCookies == maxCookies)
		{
			notice.text = "You Were Seen and All Cookies Found";
			noticeOppacity = 1;
			totalCookies = 0;
			endOverlay.SetActive(true);
			Time.timeScale = 0;
		}
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
