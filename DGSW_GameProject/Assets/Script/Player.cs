using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

	public Text Point
	{
		get
		{
			return _point;
		}
		private set
		{
			_point = value;
		}
	}
	public float JumpPower
	{
		get
		{
			return _jumpPower;
		}
		private set
		{
			_jumpPower = value;
		}
	}
	public Vector3 ViewAngle
	{
		get
		{
			return _viewAngle;
		}
		private set
		{
			_viewAngle = value;
		}
	}

	private Rigidbody2D viewModel;
	private Animator anim;
	private int pointInt = 0;
	private float time = 0;

	private Vector3 _viewAngle;
	private float _jumpPower;
	private Text _point;

	void Start()
	{
		viewModel = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		anim.SetBool("dead", false);
		viewModel.gravityScale = 0;
		JumpPower = 5.0f;
	}

	void Update()
	{
		if (!Global.timeup)
			time += Time.deltaTime;

		if (time > 3f)
		{
			Global.timeup = true;
			JumpCheck();
			OutCHeck();
			viewModel.gravityScale = 1;
		}

		Point.text = "점수: " + pointInt;
	}

	void JumpCheck()
	{
		if ((Input.touchCount > 0 && anim.GetBool("dead") == false) || (Input.GetKeyDown(KeyCode.Space) && anim.GetBool("dead") == false))
		{
			Debug.Log("진입");
			viewModel.velocity = new Vector3(0, 0, 0);
			//gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + jumppower, transform.position.z);
			viewModel.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
		}
		_viewAngle.z = viewModel.velocity.y * 10f + 20f;
		Quaternion R = Quaternion.Euler(ViewAngle);
		gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, R, 5f);
	}

	void OutCHeck()
	{
		viewModel = GetComponent<Rigidbody2D>();
		Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
		viewPos.x = Mathf.Clamp01(viewPos.x);
		viewPos.y = Mathf.Clamp01(viewPos.y);
		Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
		transform.position = worldPos;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag.Equals("Something") || other.gameObject.tag.Equals("Ground"))
		{
			Debug.Log("충돌");
			anim.SetBool("dead", true);
			Global.point = pointInt;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals("Something"))
		{
			pointInt += 1;
			Debug.Log("통과: " + pointInt);
		}
	}
}
