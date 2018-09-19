using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {
    public float scrollSpeed;
    //float targetOffset;
    // Use this for initialization

    float randomY;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Global.timeup) { 
            transform.Translate(scrollSpeed * Time.deltaTime, 0, 0);
            if (transform.localPosition.x <= -14.26f)
            {
                if (gameObject.tag.Equals("Something"))
                {
                    Randmoing();
                    transform.localPosition = new Vector3(13.04f, randomY, transform.localPosition.z);

                }
                else
                {
                    transform.localPosition = new Vector3(13.04f, transform.localPosition.y, transform.localPosition.z);
                }
            }
        }
	}

    void Randmoing()
    {
        randomY = Random.Range(5.76f, -4.39f);
    }
}
