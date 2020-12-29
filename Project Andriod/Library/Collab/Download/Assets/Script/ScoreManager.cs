using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    public static int score;
    


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("Lv");

        if (instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int coinValue)
    {

        score += coinValue;
        text.text = "X" + score.ToString();
        Debug.Log("x : " + score);



        
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Main");

    }

}
