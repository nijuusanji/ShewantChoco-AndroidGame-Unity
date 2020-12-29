using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    public static int Bosshealth = 10;
    public float bulletSpeed = 400f;

   
    public Transform barrel;
    public Rigidbody2D bullet;

    private void Start()
    {
        InvokeRepeating("BossFire", 0, 2f);
        
    }

    void BossFire()
    {
        //anim.Play("Cfull_hathum_attack");
        var fireBullet = Instantiate(bullet, barrel.position, barrel.rotation);
        fireBullet.AddForce(barrel.up * bulletSpeed);
        
    }
 


}
