using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
	public Text Label;

	void Start()
	{
		Label.text = "님 점수: " + Global.Score;
	}
}