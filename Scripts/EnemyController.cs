using System;
using UnityEngine;

public class EnemyController1 : MonoBehaviour
{
	private void Start()
	{
		this.initialPos = base.transform.position;
	}

	private void Update()
	{
		float num = 1f;
		if (this.direction == -1)
		{
			num = 2f;
		}
		float num2 = num * this.speed * Time.deltaTime * (float)this.direction;
		float num3 = base.transform.position.y + num2;
		if (Mathf.Abs(num3 - this.initialPos.y) > this.rangeY)
		{
			this.direction *= -1;
		}
		else
		{
			base.transform.position += new Vector3(0f, num2, 0f);
		}
	}

	public float speed = 3f;

	private int direction = 1;

	public float rangeY = 2f;

	private Vector3 initialPos;
}
