using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
	public static MusicPlayer Instance
	{
		get
		{
			return MusicPlayer.instance;
		}
	}

	private void Awake()
	{
		if (MusicPlayer.instance != null && MusicPlayer.instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		MusicPlayer.instance = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Update()
	{
		if (SceneManager.GetActiveScene().name == "GameOver")
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		MusicPlayer.instance = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	private static MusicPlayer instance;
}
