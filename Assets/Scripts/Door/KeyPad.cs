using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;


public class KeyPad : MonoBehaviour
{

    public DoorController doorToOpen;
    public GameObject keyPadUI;
    public TextMeshProUGUI passwordText;
    public string password;


    private AudioSource aSource;
    public AudioClip buttonAC;
    public AudioClip trueAC;
    public AudioClip falseAC;


    public GameObject dropText;
    public Controller playerScript;



    void Start()
    {
        aSource = GetComponent<AudioSource>();
        
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            playerScript.enabled = true;
            keyPadUI.SetActive(false);
            dropText.SetActive(false);

        }

        if (keyPadUI.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            keyPadUI.SetActive(true);
            playerScript.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            dropText.SetActive(true);


        }
    }

    public void KeyButton(string key)
    {
        passwordText.text = passwordText.text + key;
        aSource.PlayOneShot(buttonAC);

    }

    public void ResetPassword()
    {
        passwordText.text = "";
        aSource.PlayOneShot(falseAC);
    }

    public void CheckPassword()
    {

        if (passwordText.text == password)
        {

            doorToOpen.isLocked = false;
            doorToOpen.CheckDoor();
            keyPadUI.SetActive(false);
            
                
            dropText.SetActive(false);
            playerScript.enabled = true;
            aSource.PlayOneShot(trueAC);




        }
        else
        {
            ResetPassword();
            aSource.PlayOneShot(falseAC);
        }


    }
}
        



   




   

