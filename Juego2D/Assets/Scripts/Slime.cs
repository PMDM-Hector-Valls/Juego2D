using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private float Speed = 1.0f;
    public float lateralMovement = 2.0f;
    public int scale = 1;
    public Transform groundCheck;

    private Rigidbody2D Rigidbody2D;
    public bool gounded = true;

    public Vector3 destination;
    public float time;
    private float seconds;
    
    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash ("position", destination, "time", time,
                                                "easetype", iTween.EaseType.easeInOutSine,
                                                "looptype", iTween.LoopType.pingPong)); 
        
    }

    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= time){
            transform.localScale = new Vector3(-scale, scale, 0);
        } 
        if (seconds >= (time*2)){
            transform.localScale = new Vector3(scale,scale,0);
            seconds=0;
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
