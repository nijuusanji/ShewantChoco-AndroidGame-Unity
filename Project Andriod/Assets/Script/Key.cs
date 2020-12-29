using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    //public static int KeyValue = 1;

    public GameObject Uikey;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Playercon.PlayerKey += 1;
            Destroy(gameObject);
            Uikey.SetActive(true);
            
        }
    }
}
