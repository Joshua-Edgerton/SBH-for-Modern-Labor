using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private void Start()
	{
		this.CameraFollowPlayer();
		this.rb = base.GetComponent<Rigidbody>();
		this.col = base.GetComponent<Collider>();
		this.size = this.col.bounds.size;
	}

	private void FixedUpdate()
	{
		this.CameraFollowPlayer();
		this.WalkHandler();
		this.JumpHandler();
	}

	private void WalkHandler()
	{
		float axis = UnityEngine.Input.GetAxis("Horizontal");
		float axis2 = UnityEngine.Input.GetAxis("Vertical");
		Vector3 b = new Vector3(axis * this.walkSpeed * Time.deltaTime, 0f, axis2 * this.walkSpeed * Time.deltaTime);
		Vector3 position = base.transform.position + b;
		this.rb.MovePosition(position);
		if (axis != 0f || axis2 != 0f)
		{
			Vector3 forward = new Vector3(axis, 0f, axis2);
			this.rb.rotation = Quaternion.LookRotation(forward);
		}
	}

	private void JumpHandler()
	{
		float axis = UnityEngine.Input.GetAxis("Jump");
		if (axis > 0f)
		{
			bool flag = this.CheckGrounded();
			if (!this.pressedJump && flag)
			{
				this.pressedJump = true;
				Vector3 force = new Vector3(0f, axis * this.jumpForce, 0f);
				this.rb.AddForce(force, ForceMode.VelocityChange);
			}
		}
		else
		{
			this.pressedJump = false;
		}
	}

	private bool CheckGrounded()
	{
		Vector3 origin = base.transform.position + new Vector3(this.size.x / 2f, -this.size.y / 2f + 0.01f, this.size.z / 2f);
		Vector3 origin2 = base.transform.position + new Vector3(-this.size.x / 2f, -this.size.y / 2f + 0.01f, this.size.z / 2f);
		Vector3 origin3 = base.transform.position + new Vector3(this.size.x / 2f, -this.size.y / 2f + 0.01f, -this.size.z / 2f);
		Vector3 origin4 = base.transform.position + new Vector3(-this.size.x / 2f, -this.size.y / 2f + 0.01f, -this.size.z / 2f);
		bool flag = Physics.Raycast(origin, -Vector3.up, 0.03f);
		bool flag2 = Physics.Raycast(origin2, -Vector3.up, 0.03f);
		bool flag3 = Physics.Raycast(origin3, -Vector3.up, 0.03f);
		bool flag4 = Physics.Raycast(origin4, -Vector3.up, 0.03f);
		return flag || flag2 || flag3 || flag4;
	}

	private void increaseLVL()
	{
		GameM.instance.increaseLevel();
	}

	private void Resetthegame()
	{
		GameM.instance.GameOver();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Coin"))
		{
			GameM.instance.increaseScore(1);
			this.coinSound.Play();
			UnityEngine.Object.Destroy(other.gameObject);
		}
		else if (other.CompareTag("Enemy"))
		{
			this.enemySound.Play();
			this.hurtSound.Play();
			base.Invoke("Resetthegame", 0.2f);
		}
		else if (other.CompareTag("Goal"))
		{
			this.goalSound.Play();
			base.Invoke("increaseLVL", 0.5f);
		}
		else if (other.CompareTag("DeathGround"))
		{
			this.death.Play();
			this.enemySound.Play();
			base.Invoke("Resetthegame", 0.2f);
		}
	}

	private void CameraFollowPlayer()
	{
		Vector3 position = Camera.main.transform.position;
		position.z = base.transform.position.z - this.cameraDistZ;
		Camera.main.transform.position = position;
	}

	public float walkSpeed = 3f;

	public float jumpForce = 3f;

	public AudioSource coinSound;

	public AudioSource goalSound;

	public AudioSource enemySound;

	public AudioSource hurtSound;

	public AudioSource death;

	public float cameraDistZ = 6f;

	private Rigidbody rb;

	private Collider col;

	private bool pressedJump;

	private Vector3 size;
}
