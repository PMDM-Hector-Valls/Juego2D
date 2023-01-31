using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public GameObject winWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Gold"){
            print("The boxes are now together");
            GameManager.boxesTogether=true;
            if(GameManager.gems==0){
                Destroy(winWall);
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        print("hola");
        if (other.gameObject.tag == "Gold"){
            print("The boxes are no longer together");
            GameManager.boxesTogether=false;
        }
    }
}
