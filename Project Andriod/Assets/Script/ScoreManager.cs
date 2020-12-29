using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text text;
    public static int score;
    



    // Start is called before the first frame update
    void Start()
    {
        

        if (instance == null)
        {
            instance = this;
        }
        
    }

    private void Update()
    {
        Score();
        
    }
    
    public void Score()
    {
        text.text = score.ToString() + "/"+"3";
        
    }

  

}
