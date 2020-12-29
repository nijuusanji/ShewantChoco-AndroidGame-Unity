using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ladder : MonoBehaviour
{
    public float speed = 10;
    //public GameObject balloon;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
           
        }
        
    }

}
