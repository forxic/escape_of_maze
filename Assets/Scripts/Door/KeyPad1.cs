using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyPad1 : MonoBehaviour
{
    public DoorController doorToOpen;
    public GameObject keyPadUI1;
    public TextMeshProUGUI passwordText1;
    public string password1;


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
            keyPadUI1.SetActive(false);
            dropText.SetActive(false);

        }

        if (keyPadUI1.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            keyPadUI1.SetActive(true);
            playerScript.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            dropText.SetActive(true);


        }
    }

    public void KeyButton(string key)
    {
        
        passwordText1.text = passwordText1.text + key;
        aSource.PlayOneShot(buttonAC);
        

    }

    public void ResetPassword()
    {
        passwordText1.text = "";
        aSource.PlayOneShot(falseAC);
    }

    public void CheckPassword()
    {

        if (passwordText1.text == password1)
        {

            doorToOpen.isLocked = false;
            doorToOpen.CheckDoor();
            keyPadUI1.SetActive(false);


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
