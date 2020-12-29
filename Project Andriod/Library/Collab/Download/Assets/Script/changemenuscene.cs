using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changemenuscene : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1f;
        PlayerController.PlayerHP = 1;
        ScoreManager.score = 0;
        EnemyHit.health = 5;
    }
    public void changescene(string scenename)
    {
        Application.LoadLevel(scenename);
        Debug.Log("Changed");
        Time.timeScale = 1f;
    }

    public void doquit()
    {
        Debug.Log("QUIT!");
        Application.Quit();
       
    }

}
