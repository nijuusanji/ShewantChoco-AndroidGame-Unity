using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{

    public static int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //ScoreManager.instance.ChangeScore(coinValue);
            ScoreManager.score += coinValue;
           
        }
    }

}
