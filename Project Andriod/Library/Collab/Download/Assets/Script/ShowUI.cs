using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ShowUI : MonoBehaviour
{
    public GameObject uiObject;
    public static bool win = false;



    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            StartCoroutine(Showwin());
            Debug.Log("Win");
            win = true;
            Dictionary<string, object> customParamWin = new Dictionary<string, object>();
            customParamWin.Add("Win", win);
            customParamWin.Add("Time played", Time.timeSinceLevelLoad);
            AnalyticsEvent.Custom("Win", customParamWin);
           
        }
    }

  

    IEnumerator Showwin()
    {
        
        yield return new WaitForSeconds(0f);
        uiObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
