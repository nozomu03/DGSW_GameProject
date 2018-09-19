﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {
    public void GameReset()
    {
        SceneManager.LoadScene("SampleScene");
        Global.Timeup = false;
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
