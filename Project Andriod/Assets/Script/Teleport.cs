using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject Portal;
    public GameObject Player;
    // Start is called before the first frame update\


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Teleports());
            Debug.Log("Teleport");
        }
    }

    IEnumerator Teleports()
    {
        yield return new WaitForSeconds(0.5f);
        Player.transform.position = new Vector2(Portal.transform.position.x, Portal.transform.position.y);
    }
}
