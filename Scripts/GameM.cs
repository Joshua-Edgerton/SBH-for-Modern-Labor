using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameM : MonoBehaviour
{
	private void Awake()
	{
		if (GameM.instance == null)
		{
			GameM.instance = this;
		}
		else if (GameM.instance != this)
		{
			GameM.instance.hudManager = UnityEngine.Object.FindObjectOfType<HUDManager>();
			UnityEngine.Object.Destroy(base.gameObject);
		}
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		this.hudManager = UnityEngine.Object.FindObjectOfType<HUDManager>();
	}

	public void increaseScore(int amount)
	{
		this.score += amount;
		if (this.hudManager != null)
		{
			this.hudManager.ResetHUD();
		}
		MonoBehaviour.print("new score: " + this.score);
		if (this.score > this.highScore)
		{
			this.highScore = this.score;
			MonoBehaviour.print("New Highscore! " + this.highScore);
		}
	}

	private void Start()
	{
	}

	public void ResetGame()
	{
		this.score = 0;
		if (this.hudManager != null)
		{
			this.hudManager.ResetHUD();
		}
		this.currentLVL = 1;
		SceneManager.LoadScene("Level1");
	}

	public void increaseLevel()
	{
		if (this.currentLVL < this.highestLVL)
		{
			this.currentLVL++;
		}
		else
		{
			this.currentLVL = 1;
		}
		SceneManager.LoadScene("level" + this.currentLVL);
	}

	public void GameOver()
	{
		SceneManager.LoadScene("GameOver");
	}

	public int score;

	public static GameM instance;

	public int highScore;

	public int currentLVL = 1;

	public int highestLVL = 2;

	private HUDManager hudManager;
}
