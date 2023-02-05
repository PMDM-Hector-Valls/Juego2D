using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;


public class Character : MonoBehaviour
{
    public float Speed=0.0f;
    public float lateralMovement = 2.0f;
    public float jumpMovement = 400.0f;


    public Transform groundCheck;

    private Animator animator;
    private bool moveRight;
    private bool moveLeft; 
    private Rigidbody2D rigidbody2d;

    public bool grounded=true;
    
    private AudioSource audioSource;
    void Start()
    {
        print(GameManager.currentLevel);
        print(GameManager.currentLevel);
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        moveRight = false;
        moveLeft = false; 
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update() {
                grounded = Physics2D.Linecast(transform.position,
                                                    groundCheck.position,
                                                            LayerMask.GetMask("Ground"));
/*
        if (grounded && Input.GetButtonDown("Jump"))
                rigidbody2d.AddForce (Vector2.up * jumpMovement);
*/
        if (grounded)
                animator.SetTrigger("Grounded");
        else
                animator.SetTrigger("Jump");
                

/*
        Speed = lateralMovement * Input.GetAxis("Horizontal");
        

        if (Speed < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
            */
         transform.Translate(Vector2.right * Speed * Time.deltaTime);
        
        animator.SetFloat("Speed", Mathf.Abs(Speed));
    }

    public void jump(){
        if (grounded){
            rigidbody2d.AddForce (Vector2.up * jumpMovement);
            audioSource.Play();
        }
    }
    public void left(){
        Speed = lateralMovement * -1;
        transform.localScale = new Vector3(-1, 1, 1);
    }
    public void leftOff(){
        Speed = lateralMovement * 0;
        transform.localScale = new Vector3(1, 1, 1);
    }
    
    public void right(){
        Speed = lateralMovement * 1;
        transform.localScale = new Vector3(1, 1, 1);
    }
    public void rightOff(){
        Speed = lateralMovement * 0;
        transform.localScale = new Vector3(1, 1, 1);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "MobilePlatform"){
            transform.SetParent(other.transform);
        }

        if (other.gameObject.tag == "Enemy"){
            SceneManager.LoadScene("Lose");
        }
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ZOOM"){
            GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().enabled = false;
            print(false);
        }
         if (other.gameObject.tag == "gem"){
            GameManager.gems--;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "win"){
            GameManager.currentLevel++;
            print(GameManager.currentLevel);
            SceneManager.LoadScene("Nivel2");
        }
        if (other.gameObject.tag == "Goal"){
            SceneManager.LoadScene("WinScreen");
        }
        
        if (other.gameObject.tag == "deadZone"){
            SceneManager.LoadScene("Lose");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "ZOOM"){
            GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().enabled = true;
        }
    }


    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MobilePlatform"){
            transform.SetParent(null);
        }
    }
    
    
}
