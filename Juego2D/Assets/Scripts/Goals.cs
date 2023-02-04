using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goals : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Nivel1");
    }
}
