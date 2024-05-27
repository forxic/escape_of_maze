using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioSource fx;
    public AudioClip hoverfx;
    public AudioClip clickfx;

    public void HoverSound()
    {
        fx.PlayOneShot(hoverfx);
    }

    public void ClickSound()
    {
        fx.PlayOneShot(clickfx);
    }
}
