using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goals : MonoBehaviour
{
    public void StartButton()
    {
        GameManager.currentLevel=0;
        GameManager.currentLevel++;
        print(GameManager.currentLevel);
        SceneManager.LoadScene("Nivel1");
    }
}
