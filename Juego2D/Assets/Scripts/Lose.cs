using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    public void ReplayButton()
    {
        print("Enviando a " + GameManager.currentLevel);
        SceneManager.LoadScene(GameManager.currentLevel);
    }
    
}
