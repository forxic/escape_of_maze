using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuContrroller : MonoBehaviour
{



    public void LoadMenuScene()
    {
        // Menü sahnesinin adýný buraya yazýn, örneðin "MainMenu"
        SceneManager.LoadScene(0);
    }
    
}

