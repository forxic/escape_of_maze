using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKLook : MonoBehaviour
{
    float weight = 1f;
    Animator anim;
    Camera mainCam;
    





    void Start()
    {
        anim= GetComponent<Animator>(); 
        mainCam= Camera.main;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        anim.SetLookAtWeight(weight, 0.5f, 1.2f, 0.5f, 0.5f);
       
        Ray lookAtRay = new Ray(transform.position, mainCam.transform.forward);
        
        anim.SetLookAtPosition(lookAtRay.GetPoint(25));
    }


    public void art()
    {
        weight = Mathf.Lerp(weight, 1f, Time.fixedDeltaTime);
    }


    public void azal()
    {
        weight = Mathf.Lerp(weight, 0f, Time.fixedDeltaTime);
    }


}
