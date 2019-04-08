using System;
using UnityEngine;

public class Coincontroller : MonoBehaviour
{
	private void Start()
	{
		this.initialPos = base.transform.position;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			UnityEngine.Object @object = UnityEngine.Object.Instantiate<GameObject>(this.coinParticleeffect, this.initialPos, base.transform.rotation);
		}
	}

	private void Update()
	{
		float d = this.rotationSpeed * Time.deltaTime;
		base.transform.Rotate(Vector3.up * d, Space.World);
		float num = this.vertSpeed * Time.deltaTime * this.direction;
		float num2 = base.transform.position.y + num;
		if (Mathf.Abs(num2 - this.initialPos.y) > this.rangeY)
		{
			this.direction *= -1f;
		}
		else
		{
			base.transform.position += new Vector3(0f, num, 0f);
		}
	}

	public float rotationSpeed = 100f;

	private Vector3 initialPos;

	public float vertSpeed = 1f;

	public float rangeY = 1f;

	public float direction = 1f;

	public ParticleSystem coinParticle;

	public GameObject coinParticleeffect;
}