using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    private string gameIdIOS = "3336689";
    private string gameIdAndroid = "3336688";
    string myPlacementId = "rewardedVideo";
    bool testMode = false;
    ShowOptions options = new ShowOptions();
    public bool adStarted;
    public bool adCompleted;


    Scene thisScene;
    float currentTime = 0f;
    float startingTime = 100f; //ตั้งเวลาเริ่มเกมเป็น 5 วิ
    public GameObject uiOver;
    public GameObject watchover;
    

    [SerializeField] Text CountdownText;

    void Awake()
    {
        AnalyticsEvent.GameStart();
        thisScene = SceneManager.GetActiveScene();
        AnalyticsEvent.LevelStart(thisScene.name, thisScene.buildIndex);
    }

    void Start()
    {
        currentTime = startingTime;
#if UNITY_IOS
        Advertisement.Initialize(gameIdIOS, testMode);
#else
        Advertisement.Initialize(gameIdAndroid, testMode);
#endif
    }

    // Update is called once per frame
    void Update() //สำหรับตั้งเวลาถอยหลัง
    {
        currentTime -= 1 * Time.deltaTime;
        CountdownText.text = currentTime.ToString("0");

        if(currentTime <= 0) //Movefirejump.PlayerHP <= 0
        {
            currentTime = 0;
            uiOver.SetActive(true); //ถ้าเวลาหมดก็ให้โชว์ panel ads
            Time.timeScale = 0f;
            Debug.Log("ShowOverPanel");
        }
        if(Movefirejump.PlayerHP <= 0) //Movefirejump.PlayerHP <= 0
        {
            
            uiOver.SetActive(true); //ถ้าเวลาหมดก็ให้โชว์ panel ads
            Time.timeScale = 0f;
            Debug.Log("ShowOverPanel");
        }


    }

    public void ShowAd() //codeเอามาใส่ไว้ในปุ่ม watch ads
    {
        if (Advertisement.IsReady(myPlacementId) && !adStarted)
        {
            options.resultCallback = AdDisplayResultCallback;
            Advertisement.Show(myPlacementId, options);
            adStarted = true;
            
            
        }
        
    }
    

    private void AdDisplayResultCallback(ShowResult result) //ถ้าเรียกfunctionนี้ จะมี result กลับมาด้วย
    {
        switch (result)
        {
            case ShowResult.Finished: //ถ้ากดดู Ad จะได้ เวลาเพิ่มเป็น 50 วิ
                Debug.Log("Ads finished");
                currentTime += 50; //ตั้งเวลาให้เป็น +50 วิ
                adCompleted = true;
                Time.timeScale = 1f;
                PlayerController.PlayerHP = 1;
                StartCoroutine(Immortal());
                
                uiOver.SetActive(false);
                watchover.SetActive(false);

                Dictionary<string, object> customParamA = new Dictionary<string, object>();
                customParamA.Add("Ad finished", adCompleted);
                
                AnalyticsEvent.Custom("Analytic", customParamA);

                Dictionary<string, object> customParamSco = new Dictionary<string, object>();
                customParamSco.Add("Score", ScoreManager.score);
                AnalyticsEvent.Custom("Score", customParamSco);
        

        break;
            
            case ShowResult.Failed: //ถ้าเกิดเน็ตหลุดหรืออะไรก็ไม่ได้
                Debug.Log("Ads failed");
                break;
        }
    }
    IEnumerator Immortal()
    {
        PlayerController.PlayerHP = 200;
        yield return new WaitForSeconds(2f);
        PlayerController.PlayerHP = 1;
    }
    
}
