using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameMenu : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;  // Skoru g�sterecek olan TextMeshPro objesi

    void Start()
    {
        finalScoreText.text = "Skor: " + GameManager.playerScore;
    }
}

