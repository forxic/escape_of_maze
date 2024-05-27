using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    private float skor;
    private float timer;
    void Start()
    {
        skor = 0;
        timer = 0;
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            timer = 0;
            UpdateScore(1);
        }
        scoreText.text = skor.ToString();
    }

    public void UpdateScore(int points)
    {
        skor += points;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.playerScore = skor;
            Time.timeScale = 0f; // Oyun durdurulur
            SceneManager.LoadScene(2);
        }
    }
}
