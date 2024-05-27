using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;
    EnemyAI enemy;
    public GameObject bloodEffect;
    AudioSource enemyAS;
    public AudioClip damageAC;
    // Start is called before the first frame update
    void Start()
    {
        enemy= GetComponent<EnemyAI>();
        enemyAS= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth<=0)
        {
            enemyHealth=0;
        }
    }
    public void ReduceHealth(float reduceHealth)
    {
        enemyHealth -= reduceHealth;
        
       if(!enemy.isDead )
       {
            enemy.Hurt();
            enemyAS.PlayOneShot(damageAC);
       }
        if(enemyHealth <=0)
        {
            enemy.DeadAnim();
            Dead();
        }
    }
    void Dead()
    {
        bloodEffect.SetActive(true);
        enemy.canAttack = false;
        Destroy(gameObject,10f);
    }
}
