using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Crossbow : MonoBehaviour
{
   
    RaycastHit hit;

    public ParticleSystem muzzleflash;
    AudioSource pistolAS;
    public AudioClip shootAC;
    public AudioClip emptyFire;
    public AudioClip reloadAC;

    bool isReloading;

    public int currentAmmo = 10;
    public int maxAmmo = 10;
    public int carriedAmmo = 40;

    [SerializeField]
    float rateOfFire;
    float nextFire = 0;

    [SerializeField]
    float weaponRange;

    public float damage = 20f;

    public Transform shootPoint;

    public GameObject bloodEffect;

    public TextMeshProUGUI currentAmmoText;
    public TextMeshProUGUI carriedAmmoText;

    void Start()
    {
        UpdateAmmoUI();
        UpdateAmmoUICA();
        pistolAS = GetComponent<AudioSource>();
        muzzleflash.Stop();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentAmmo > 0)
        {
            Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && currentAmmo <= 0 && !isReloading)
        {
            EmptyFire();
        }
        else if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo && !isReloading)
        {
            isReloading = true;
            pistolAS.PlayOneShot(reloadAC);
            Reload();
        }
       
        
        
        
    }

    public void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + rateOfFire;
            pistolAS.PlayOneShot(shootAC);
            currentAmmo--;
            UpdateAmmoUI();
            UpdateAmmoUICA();

            ShootRay();

            StartCoroutine(pistolEffect());
        }
    }

    void ShootRay()
    {
        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, weaponRange))
        {
            if (hit.transform.tag == "Enemy")
            {
                EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
                Instantiate(bloodEffect, hit.point, transform.rotation);
                enemy.ReduceHealth(damage);
            }
        }
        else
        {
            Debug.Log("Something else");
        }
    }

    void Reload()
    {
        if (carriedAmmo <= 0) return;

        StartCoroutine(ReloadCountDown(0.5f));
    }



    public void UpdateAmmoUI()
    {
        currentAmmoText.text=currentAmmo.ToString();
        
    }
    public void UpdateAmmoUICA()
    {
        carriedAmmoText.text = carriedAmmo.ToString();
    }
    void EmptyFire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + rateOfFire;
            pistolAS.PlayOneShot(emptyFire);
        }
    }

    IEnumerator pistolEffect()
    {
        muzzleflash.Play();
        yield return new WaitForEndOfFrame();
        muzzleflash.Stop();
    }

    IEnumerator ReloadCountDown(float timer)
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        if (timer <= 0)
        {
            isReloading = false;
            int bulletNeeded = maxAmmo - currentAmmo;
            int bulletsToLoad = (carriedAmmo >= bulletNeeded) ? bulletNeeded : carriedAmmo;

            currentAmmo += bulletsToLoad;
            carriedAmmo -= bulletsToLoad;
            UpdateAmmoUI();
            UpdateAmmoUICA();
        }
    }



}
