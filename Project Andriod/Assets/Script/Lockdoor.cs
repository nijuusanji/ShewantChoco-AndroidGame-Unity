using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockdoor : MonoBehaviour
{
    public GameObject UIkey;
    public GameObject Uishow;
    public int health = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Playercon.PlayerKey == 1)
        {
            health--;
            Debug.Log("door-");
            if (health <= 1)
            {
                Destroy(gameObject);
                UIkey.SetActive(false);
                health = 1;
                Destroy(Uishow);
            }           
        }
        if (collision.CompareTag("Player"))
        {
            Uishow.SetActive(true);
            StartCoroutine(showUI());
        }
        IEnumerator showUI()
        {
            yield return new WaitForSeconds(1f);
            Uishow.SetActive(false);
        }
    }
}