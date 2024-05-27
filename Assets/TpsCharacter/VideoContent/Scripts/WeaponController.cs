using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    
    bool canAttack=true;
    bool isStrafe=false;
    Animator anim;

    public GameObject handWeapon;
    public GameObject backWeapon;
    

    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("iS",isStrafe);
        if(Input.GetKeyDown(KeyCode.F))
        {
            isStrafe = !isStrafe;
        }

       if(Input.GetKeyDown(KeyCode.Mouse0) && isStrafe == true && canAttack == true)
        {
           
            anim.SetTrigger("Saldýr");
            
                
        }  
        
            

        if(isStrafe==true)
        {
            GetComponent<Controller>().hareketTipi=Controller.MovementType.Strafe;
            GetComponent<IKLook>().art();
        }

        if(isStrafe ==false)
        {
            GetComponent<Controller>().hareketTipi = Controller.MovementType.Directional;
            GetComponent<IKLook>().art();
        }

    }

    void equip()
    {
        backWeapon.SetActive(false);
        handWeapon.SetActive(true);
    }

    void unequip()
    {
        backWeapon.SetActive(true);
        handWeapon.SetActive(false);
    }


    


}






