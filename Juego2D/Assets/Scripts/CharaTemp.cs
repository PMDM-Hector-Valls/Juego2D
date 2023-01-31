using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaTemp : MonoBehaviour
{
    public float Speed = 0.0f;
    public float lateralMovement = 2.0f;
    public float jumpMovement = 400.0f;
    public Transform groundCheck;
    private Rigidbody2D rigidbody2D;
    public bool grounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast (transform.position, groundCheck.position, LayerMask.GetMask("Ground"));

        if (grounded && Input.GetButtonDown("Jump")){
            rigidbody2D.AddForce(Vector2.up * jumpMovement);
        }

        Speed = lateralMovement * Input.GetAxis("Horizontal");
        transform.Translate (Vector2.right * Speed * Time.deltaTime);

        if (Speed < 0){
            transform.localScale = new Vector3(1, 1, 1);
        } else {
            transform.localScale = new Vector3(-1,1,1);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "MobilePlatform"){
            transform.SetParent(other.transform);
        }
            
    }


    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MobilePlatform"){
            transform.SetParent(null);
        }
    }
}
