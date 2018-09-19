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
		if (!Global.TimeUp)
			time += Time.deltaTime;

		if (time > 3f)
		{
			Global.TimeUp = true;
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
			viewModel.velocity = Vector3.zero;
			viewModel.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
		}
		_viewAngle.z = (viewModel.velocity.y * 10f) + 20f;
		gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, Quaternion.Euler(ViewAngle), 5f);
	}

	void OutCHeck()
	{
		viewModel = GetComponent<Rigidbody2D>();
		Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
		viewPos.x = Mathf.Clamp01(viewPos.x);
		viewPos.y = Mathf.Clamp01(viewPos.y);
		transform.position = Camera.main.ViewportToWorldPoint(viewPos);
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag.Equals("Something") || other.gameObject.tag.Equals("Ground"))
		{
			anim.SetBool("dead", true);
			Global.Score = pointInt;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals("Something"))
			pointInt += 1;
	}
}