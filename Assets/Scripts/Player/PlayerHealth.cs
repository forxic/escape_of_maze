using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100f;
    public static PlayerHealth PH;

    public Slider healthBarSlider;
    public TextMeshProUGUI healthText;

    public bool isDead = false;

    private AudioSource aSource;
    public AudioClip hitAC;
    Animator anim;
    Controller controller;
    IKLook IK;



    public Vector3 chechkPos;
    public GameObject player;



    private void Awake()
    {
        PH = this;
    }

    void Start()
    {
        controller = GetComponent<Controller>();
        IK = GetComponent<IKLook>();
        anim = GetComponent<Animator>();
        aSource = GetComponent<AudioSource>();
        healthText.text = maxHealth.ToString();
        currentHealth = maxHealth;
        healthBarSlider.value = maxHealth;


    }


    void Update()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }

    }

    public void DamagePlayer(float damage)
    {

        if (currentHealth > 0)
        {
            if (damage >= currentHealth)
            {

                Dead();
            }
            else
            {
                GetComponent<Controller>().enabled = true;
                GetComponent<IKLook>().enabled = true;

                currentHealth -= damage;
                healthBarSlider.value -= damage;
                anim.SetTrigger("Hit");
                aSource.PlayOneShot(hitAC);
                UpdateText();
            }
        }
    }

    public void UpdateText()
    {
        healthText.text = currentHealth.ToString();
    }

    void Dead()
    {
        currentHealth = 0;
        isDead = true;
        healthBarSlider.value = 0;
        anim.SetTrigger("Dead");
        GetComponent<Controller>().enabled = false;
        GetComponent<IKLook>().enabled = false;

        UpdateText();
        DeadAlive();

    }

    void DeadAlive()
    {
        currentHealth = 100;
        healthBarSlider.value = 100;
        healthText.text = currentHealth.ToString();
        player.transform.position = chechkPos;
        GetComponent<Controller>().enabled = true;
        GetComponent<IKLook>().enabled = true;


        

    }

    
}
