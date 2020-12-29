using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Playercon : MonoBehaviour
{
    Rigidbody2D rb;
    float dirX;

    [SerializeField]
    float moveSpeed = 5f, jumpForce = 600f, bulletSpeed = 500f, speed = 10;

    bool facingRight = true;
    Vector3 localScale;

    public Transform groundPos;
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;

    public bool IsJumping;

    public ParticleSystem Smoke;
    public Transform barrel;
    public Rigidbody2D bullet;

    public static int PlayerHP = 1;
    public static int PlayerKey = 0;

    private Animator anim;

    void Start()
    {
        localScale = transform.localScale;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);

        dirX = CrossPlatformInputManager.GetAxis("Horizontal");
        if (isGrounded = true && rb.velocity.y == 0 && CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            anim.SetTrigger("takeOff");
            IsJumping = true;
            rb.AddForce(Vector2.up * jumpForce);
        }

        if (isGrounded == true)
        {
            anim.SetBool("IsJumping", false);
            Debug.Log("jumping false");
            //CreateSmoke(); //ถ้ากระโดดจะมีควันด้วยยตรงนี้เท่ห์สาสส
        }
        else
        {
            anim.SetBool("IsJumping", true);
        }



        if (CrossPlatformInputManager.GetButtonDown("Fire"))
        {
            Fire();
        }

        if (dirX == 0)
        {
            anim.SetBool("IsRunning", false);
        }

        else
        {
            anim.SetBool("IsRunning", true);
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    private void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else
            if (dirX < 0)
            facingRight = false;
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;
      
        transform.localScale = localScale;
    }

    void Fire()
    {
        anim.Play("Cfull_hathum_attack");
        var fireBullet = Instantiate(bullet, barrel.position, barrel.rotation);
        fireBullet.AddForce(barrel.up * bulletSpeed);
    }


    void CreateSmoke()
    {
        Smoke.Play();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            Debug.Log("KeepCoin");
        }
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBoss") || other.gameObject.CompareTag("EnemyBullet"))
        {
            PlayerHP--;

            Debug.Log("dead");
        }
        if (other.gameObject.CompareTag("balloon"))
        {
            anim.Play("Cfull_hathum_balloon");
            Debug.Log("ANimationUP!!");
        }
        
        if (other.gameObject.CompareTag("Ground"))
        {
            anim.Play("Cfull_hathum_land");
            //CreateSmoke(); //กระโดดลงพื้นจะมีควัน
        }

        if (other.gameObject.CompareTag("Time"))
        {
            CountdownTimer.currentTime += 20;
            Destroy(other.gameObject);
        }


    }
}
