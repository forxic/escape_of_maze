using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameMenu : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;  // Skoru gösterecek olan TextMeshPro objesi

    void Start()
    {
        finalScoreText.text = "Skor: " + GameManager.playerScore;
    }
}

