using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControl : MonoBehaviour {

	private float _shakeTimer = 3f;
	private const float shakeAmount = 4f;
	private Animator anim;

	public float ShakeTimer
	{
		get
		{
			return _shakeTimer;
		}

		set
		{
			_shakeTimer = value;
		}
	}

	void Start () {
        anim = GameObject.Find("Chara01").GetComponent<Animator>();
	}

	void Update () {
        if (ShakeTimer >= 0 && anim.GetBool("dead")==true && Global.Timeup==true)
        {
            Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;
            transform.position = transform.position + new Vector3(ShakePos.x, ShakePos.y, 0);

			ShakeTimer -= Time.deltaTime;
        }

        if (ShakeTimer <= 0)
            SceneManager.LoadScene("Dead");
    }
}
