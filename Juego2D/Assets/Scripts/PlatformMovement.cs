using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Vector3 destination;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash ("position", destination, "time0", time,
                                                "easetype", iTween.EaseType.easeInOutSine,
                                                "looptype", iTween.LoopType.pingPong));
    }

}
