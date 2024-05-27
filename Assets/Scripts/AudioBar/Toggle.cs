using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Toggle : MonoBehaviour
{
    public GameObject volumeSlider;
    public TextMeshProUGUI audioValue;
    public TextMeshProUGUI audioText;
    

    private bool isVisible = false;


    private void Start()
    {
        
        volumeSlider.SetActive(false);
        audioValue.gameObject.SetActive(false);
        audioText.gameObject.SetActive(false);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void ToggleElements()
    {
        isVisible = !isVisible;
        volumeSlider.SetActive(isVisible);
        audioValue.gameObject.SetActive(isVisible);
        audioText.gameObject.SetActive(isVisible);
    }

    void OnDestroy()
    {
        // Scene de�i�ikli�i dinleyicisini kald�r
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Yeni sahne y�klendi�inde elementleri gizle
        
        volumeSlider.SetActive(false);
        audioValue.gameObject.SetActive(false);
        audioText.gameObject.SetActive(false);
    }
}
