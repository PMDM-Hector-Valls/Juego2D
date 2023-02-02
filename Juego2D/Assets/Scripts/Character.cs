using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Character : MonoBehaviour
{
    public float Speed=0.0f;
    public float lateralMovement = 2.0f;
    public float jumpMovement = 400.0f;

    public Transform groundCheck;

    private Animator animator;
    private Rigidbody2D rigidbody2d;

    public bool grounded=true;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    void Update() {
                grounded = Physics2D.Linecast(transform.position,
                                                    groundCheck.position,
                                                            LayerMask.GetMask("Ground"));

        if (grounded && Input.GetButtonDown("Jump"))
                rigidbody2d.AddForce (Vector2.up * jumpMovement);

        if (grounded)
                animator.SetTrigger("Grounded");
        else
                animator.SetTrigger("Jump");

        Speed = lateralMovement * Input.GetAxis("Horizontal");
        
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
        
        animator.SetFloat("Speed", Mathf.Abs(Speed));

        if (Speed < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "MobilePlatform"){
            transform.SetParent(other.transform);
        }

        if (other.gameObject.tag == "Enemy"){
            SceneManager.LoadScene(3);
        }
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.tag == "gem"){
            GameManager.gems--;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "win"){
            SceneManager.LoadScene(2);
        }
        
        if (other.gameObject.tag == "deadZone"){
            SceneManager.LoadScene(3);
        }
    }


    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MobilePlatform"){
            transform.SetParent(null);
        }
    }
    
    
}
