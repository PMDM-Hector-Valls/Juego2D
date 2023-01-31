using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private float Speed = 1.0f;
    public float lateralMovement = 2.0f;
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
            transform.localScale = new Vector3(-1, 1, 1);
        } 
        if (seconds >= (time*2)){
            transform.localScale = new Vector3(1,1,1);
            seconds=0;
        }
    }
   
}
