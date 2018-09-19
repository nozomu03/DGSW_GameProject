using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour {
    public Text txt;
	// Use this for initialization
	void Start () {
        txt.text = "님 점수: " + Global.point;
	}
}
