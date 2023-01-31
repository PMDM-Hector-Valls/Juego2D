using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
    public Vector3 destination;
    public float time;
    
    void Start()
    {
     iTween.MoveTo(gameObject, iTween.Hash ("position", destination, "time0", time,
                                                "easetype", iTween.EaseType.easeInOutSine,
                                                "looptype", iTween.LoopType.pingPong));  
    }

   
}
