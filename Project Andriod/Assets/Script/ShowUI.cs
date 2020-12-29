using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ShowUI : MonoBehaviour
{
    public GameObject uiObject;
    public GameObject uiPlay;
    public GameObject uiCloseOb;
    public GameObject Res;
    public GameObject UiCho;
    public GameObject desuisend;
  

    public static bool win = false;



    void OnTriggerEnter2D(Collider2D player)
    {

        if(player.gameObject.tag == "Player" && ScoreManager.score >= 3)
        {   
            StartCoroutine(Showwin());
            Debug.Log("Win");
            win = true;
            Dictionary<string, object> customParamWin = new Dictionary<string, object>();
            customParamWin.Add("Win", win);
            customParamWin.Add("Time played", Time.timeSinceLevelLoad);
            AnalyticsEvent.Custom("Win", customParamWin);
            Destroy(UiCho);
            Destroy(desuisend);

        }
            

        
        if(player.gameObject.tag == "Player")
        {
            
            UiCho.SetActive(true);
            StartCoroutine(ShowCho());
            
        }
        IEnumerator ShowCho()
        {

            yield return new WaitForSeconds(1f);
            UiCho.SetActive(false);
            Debug.Log("setfalse");
        }
    }

     IEnumerator Showwin()
    {
        yield return new WaitForSeconds(0f);
        Res.SetActive(false);
        uiObject.SetActive(true);
        uiPlay.SetActive(false);
        uiCloseOb.SetActive(false);
        Time.timeScale = 0f;

    }
    
}
