using System;
using System.Collections;
using UnityEngine;

public class coinpartdelete : MonoBehaviour
{
	private void Start()
	{
		base.StartCoroutine("DestroyMe");
	}

	private IEnumerator DestroyMe()
	{
		yield return new WaitForSeconds(1f);
		UnityEngine.Object.Destroy(base.gameObject);
		yield break;
	}

	private void Update()
	{
	}
}