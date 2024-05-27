using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject activeCross;
    public GameObject fullHealthText;
    public GameObject medkitBox;
    public AudioClip healSound; // Ses dosyasý için AudioClip
    public GameObject audioPlayer; // Yeni AudioPlayer GameObject referansý
    private AudioSource audioSource; // AudioSource referansý
    PlayerHealth player;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
        if (audioPlayer != null)
        {
            audioSource = audioPlayer.GetComponent<AudioSource>();
        }

        // Debug: AudioSource bileþeninin baþarýyla alýnýp alýnmadýðýný kontrol et
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing on the audioPlayer GameObject.");
        }
    }

    private void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
        InputButton();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            demo();
        }
    }

    private void demo()
    {
        if (theDistance <= 5)
        {
            if (player.currentHealth == 100)
            {
                actionKey.SetActive(false);
                activeCross.SetActive(true);
                fullHealthText.SetActive(true);
            }
            else if (player.currentHealth < 100)
            {
                actionKey.SetActive(true);
                activeCross.SetActive(true);
            }
        }
        else
        {
            actionKey.SetActive(false);
            activeCross.SetActive(false);
        }
    }

    private void InputButton()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (theDistance <= 5)
            {
                if (player.currentHealth < 100)
                {
                    player.currentHealth += 25;
                    player.UpdateText();
                    player.healthBarSlider.value += 25;

                    Debug.Log("Heal sound should play now."); // Log ekleyin
                    if (audioSource != null && healSound != null)
                    {
                        audioSource.PlayOneShot(healSound); // Heal sesini çal
                    }

                    actionKey.SetActive(false);
                    activeCross.SetActive(false);
                    Destroy(medkitBox);
                }
            }
        }
    }

    private void OnTriggerExit()
    {
        actionKey.SetActive(false);
        activeCross.SetActive(false);
        fullHealthText.SetActive(false);
    }
}
