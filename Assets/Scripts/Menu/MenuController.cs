using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuContrroller : MonoBehaviour
{



    public void LoadMenuScene()
    {
        // Men� sahnesinin ad�n� buraya yaz�n, �rne�in "MainMenu"
        SceneManager.LoadScene(0);
    }
    
}

