using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
	private void Start()
	{
		this.scoreValue.text = GameM.instance.score.ToString();
		this.highscoreValue.text = GameM.instance.highScore.ToString();
	}

	public void RestartGame()
	{
		GameM.instance.ResetGame();
		SceneManager.LoadScene("level1");
	}

	public void HomeScene()
	{
		SceneManager.LoadScene("Home");
	}

	public Text scoreValue;

	public Text highscoreValue;
}
