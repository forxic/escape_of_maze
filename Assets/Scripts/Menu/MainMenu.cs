using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject loatText;
    public Toggle tg;
    
    void Start()
    {
        if (tg != null)
        {
            // SettingsToggle scriptindeki objeleri kapat
            tg.volumeSlider.SetActive(false);
            tg.audioValue.gameObject.SetActive(false);
            tg.audioText.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("SettingsToggle script is not assigned.");
        }
    }

    public void NewGameButton()
    {
        StartCoroutine(NewGame());
    }

    IEnumerator NewGame()
    {
        
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        loatText.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }
    
}
