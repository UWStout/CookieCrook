using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreOverlayController : MonoBehaviour
{
	//references needed to get information or set text
	public playerController player;
	public Text initialScore;
	public Text timeScore;
	public Text lifeScore;
	public Text difficultyScore;
	public Text finalScore;

	//time between scores being calculated
	public float timeBetween;

	//bonus based on the difficulty of level chosen
	public int difficultyBonus;

	private int score;
	private int timeLeft;
	private int lifeCount;

	private int final;

	private void OnEnable()
	{
		score = player.getScore();
		timeLeft = player.getTime();
		lifeCount = player.lives;

		StartCoroutine(calculateScores());
	}

	private IEnumerator calculateScores()
	{
		yield return new WaitForSecondsRealtime(timeBetween);

		initialScore.text = "Initial Score:     " + score;

		yield return new WaitForSecondsRealtime(timeBetween);

		timeScore.text = "Time Bonus:    10 X " + timeLeft;

		yield return new WaitForSecondsRealtime(timeBetween);

		lifeScore.text = "Extra Lives:      1000 X " + lifeCount;

		yield return new WaitForSecondsRealtime(timeBetween);

		difficultyScore.text = "Difficulty Bonus:      " + difficultyBonus;

		yield return new WaitForSecondsRealtime(timeBetween);

		final += (lifeCount * 1000);
		final += (timeLeft * 10);
		final += score;
		final += difficultyBonus;

		finalScore.text = "Final Score:   " + final;

		yield return new WaitForSecondsRealtime(5f);

		Time.timeScale = 1;
		SceneManager.LoadScene(0);
	}
}
