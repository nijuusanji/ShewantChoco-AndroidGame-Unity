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

    public Transform barrel;
    public Rigidbody2D bullet;
    public GameObject balloon;
    

    public static int PlayerHP = 1;

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
        if (isGrounded = true && CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            anim.SetTrigger("takeOff");
            IsJumping = true;
            rb.AddForce(Vector2.up * jumpForce);
            //Debug.Log("takeoff");
        }

        if (isGrounded == true)
        {
            anim.SetBool("IsJumping", false);
            Debug.Log("jumping false");
        }
        else
        {
            anim.SetBool("IsJumping", true);
            //Debug.Log("jumping true");
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

    //void Jump()
    //{
    //    if (rb.velocity.y == 0)
    //    {
    //        anim.SetTrigger("takeOff")
    //        rb.AddForce(Vect or2.up * jumpForce);
    //    }
    //    else
    //    {
    //        anim.SetBool("IsJumpping", true);
    //    }

    //}

    void Fire()
    {
        anim.Play("Cfull_hathum_attack");
        var fireBullet = Instantiate(bullet, barrel.position, barrel.rotation);
        fireBullet.AddForce(barrel.up * bulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            Debug.Log("KeepCoin");
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            PlayerHP--;

            Debug.Log("dead");
        }
        if (other.gameObject.CompareTag("balloon"))
        {
            balloon.SetActive(true);
            anim.Play("Cfull_hathum_balloon");
            Debug.Log("ANimationUP!!");
            
        }
        //if (other.gameObject.CompareTag("DestroyBalloon"))
        //{
        //    balloon.SetActive(false);
        //    Debug.Log("balloonGONE!");
        //    anim.Play("Cfull_hathum_idle");
            

        //}
        if (other.gameObject.CompareTag("Ground"))
        {
            anim.Play("Cfull_hathum_land");
            balloon.SetActive(false);
        }

    }

    
    
        
        
        
        
    

}
