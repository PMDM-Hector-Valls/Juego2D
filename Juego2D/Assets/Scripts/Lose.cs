using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    public void ReplayButton()
    {
        SceneManager.LoadScene("Nivel1");
    }
    
    public void ExitButton()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
