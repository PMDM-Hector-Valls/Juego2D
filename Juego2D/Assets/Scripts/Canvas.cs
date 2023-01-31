using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Canvas : MonoBehaviour
{
    public Text gems;
    public Text boxesState;

    // Start is called before the first frame update
    void Start()
    {
        gems.text = "Gems left: " + GameManager.gems;
        boxesState.text = "Boxes are separated";
    }

    // Update is called once per frame
    void Update()
    {
        gems.text = "Gems left: " + GameManager.gems;
        if(GameManager.boxesTogether == false){
            boxesState.text = "Boxes are separated";
        } else {
            boxesState.text = "Boxes are together";
        }
    }
}
