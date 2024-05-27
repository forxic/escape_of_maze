using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    private AudioSource aSource;
    [SerializeField] private AudioClip footstepSFX;
    [SerializeField] private AudioClip runstepSFX;


    private void Awake()
    {
        aSource = GetComponent<AudioSource>();
    }

    public void PlayFootstepSFX()
    {
        aSource.PlayOneShot(footstepSFX);
        
    }
    public void PlayRunstepSFX()
    {
        aSource.PlayOneShot(runstepSFX);
    }
}
