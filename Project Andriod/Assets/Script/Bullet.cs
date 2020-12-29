using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float destroyTime = 3f;

   

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("hitenemy");
            EnemyHit.health--;
            Destroy(gameObject);
            if (EnemyHit.health <= 0)
            {
                Destroy(other.gameObject);
            }

        }

        if (other.gameObject.CompareTag("EnemyBoss"))
        {
            Debug.Log("hitBoss");
            EnemyBoss.Bosshealth--;
            Destroy(gameObject);
            if (EnemyBoss.Bosshealth <= 0)
            {
                Destroy(other.gameObject);
                
            }

        }

    }



}
