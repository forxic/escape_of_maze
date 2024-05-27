using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
   

    public float theDistance;
    public GameObject actionKey;
    public GameObject activeCross;
    public GameObject fullAmmoText;
    public GameObject ammoBox;
    public AudioClip ammoSound; // Ses dosyasý için AudioClip
    public GameObject audioPlayer; // Yeni AudioPlayer GameObject referansý
    private AudioSource audioSource; // AudioSource referansý
    public Crossbow CB; // Referansý Inspector'dan atamak için public yapýldý

    private void Start()
    {
        if (CB == null)
        {
            Debug.LogError("Crossbow component is not assigned in the inspector.");
        }

        if (audioPlayer != null)
        {
            audioSource = audioPlayer.GetComponent<AudioSource>();
        }

        // Debug: AudioSource bileþeninin baþarýyla alýnýp alýnmadýðýný kontrol et
        if (audioSource == null)
        {
            audioSource.PlayOneShot(ammoSound);
            Debug.LogError("AudioSource component is missing on the audioPlayer GameObject.");
        }

        // Diðer referanslarýn null olup olmadýðýný kontrol edin
        if (actionKey == null)
        {
            Debug.LogError("actionKey GameObject is not assigned.");
        }

        if (activeCross == null)
        {
            Debug.LogError("activeCross GameObject is not assigned.");
        }

        if (fullAmmoText == null)
        {
            Debug.LogError("fullAmmoText GameObject is not assigned.");
        }

        if (ammoBox == null)
        {
            Debug.LogError("ammoBox GameObject is not assigned.");
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
            Debug.Log("Kutu alýndý: " + gameObject.name);
            demo();
        }
    }

    private void demo()
    {
        if (theDistance <= 5)
        {
            if (CB != null)
            {
                if (CB.carriedAmmo == 40)
                {
                    if (actionKey != null) actionKey.SetActive(false);
                    if (activeCross != null) activeCross.SetActive(true);
                    if (fullAmmoText != null) fullAmmoText.SetActive(true);
                }
                else if (CB.carriedAmmo < 40)
                {
                    if (actionKey != null) actionKey.SetActive(true);
                    if (activeCross != null) activeCross.SetActive(true);
                }
            }
            else
            {
                Debug.LogError("CB (Crossbow) is not assigned.");
            }
        }
        else
        {
            if (actionKey != null) actionKey.SetActive(false);
            if (activeCross != null) activeCross.SetActive(false);
        }
    }

    private void InputButton()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (theDistance <= 5)
            {
                if (CB != null && CB.carriedAmmo < 40)
                {
                    CB.carriedAmmo += 10;
                    CB.UpdateAmmoUICA();

                    Debug.Log("Heal sound should play now."); // Log ekleyin
                    if (audioSource != null && ammoSound != null)
                    {
                        audioSource.PlayOneShot(ammoSound); // Heal sesini çal
                    }

                    if (actionKey != null) actionKey.SetActive(false);
                    if (activeCross != null) activeCross.SetActive(false);
                    if (ammoBox != null) Destroy(ammoBox);
                }
               
                
            }
        }
    }

    private void OnTriggerExit()
    {
        if (actionKey != null) actionKey.SetActive(false);
        if (activeCross != null) activeCross.SetActive(false);
        if (fullAmmoText != null) fullAmmoText.SetActive(false);
    }
}




