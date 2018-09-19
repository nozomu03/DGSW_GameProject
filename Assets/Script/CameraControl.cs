using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControl : MonoBehaviour {

    public float shakeTimer = 3f;
    public float shakeAmount = 4f;
    Animator anim;


	// Use this for initialization
	void Start () {
        anim = GameObject.Find("Chara01").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (shakeTimer >= 0 && anim.GetBool("dead")==true && Global.timeup==true)
        {
            Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;

            transform.position = transform.position + new Vector3(ShakePos.x, ShakePos.y, 0);

            shakeTimer -= Time.deltaTime;
        }

        if (shakeTimer <= 0)
        {
            SceneManager.LoadScene("Dead");
        }

    }
}
