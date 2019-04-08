using System;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
	private void Start()
	{
		this.hudManager = UnityEngine.Object.FindObjectOfType<HUDManager>();
		if (this.hudManager != null)
		{
			this.hudManager.ResetHUD();
		}
	}

	public void ResetHUD()
	{
		this.scoreLabel.text = "Score: " + GameM.instance.score;
	}

	public Text scoreLabel;

	private HUDManager hudManager;
}