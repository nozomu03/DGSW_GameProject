using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {
    public float scrollSpeed;

	void Start () {
		
	}
	
	void Update () {
        if (Global.Timeup) { 
            transform.Translate(scrollSpeed * Time.deltaTime, 0, 0);
            if (transform.localPosition.x <= -14.26f)
            {
                if (gameObject.tag.Equals("Something"))
                    transform.localPosition = new Vector3(13.04f, Random.Range(5.76f, -4.39f), transform.localPosition.z);
                else
                    transform.localPosition = new Vector3(13.04f, transform.localPosition.y, transform.localPosition.z);
            }
        }
	}
}
