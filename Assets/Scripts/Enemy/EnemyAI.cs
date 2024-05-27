using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    Transform target;
    public bool isDead=false;
    public float turnSpeed;

    public bool canAttack;
    [SerializeField]
    float attackTimer=1f;

    public float damage = 25f;


    
    
    

    void Start()
    {
        canAttack = true;
        agent= GetComponent<NavMeshAgent>();
        anim= GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        if (PlayerHealth.PH == null)
        {
            Debug.LogError("PlayerHealth.PH is not assigned!");
            return;
        }


    }

    // Update is called once per frame
    void Update()
    {
        //if(isDead) return;


        float distance=Vector3.Distance(transform.position, target.position);

        if(distance <10 && distance > 2 && !isDead)
        {
            ChasePlayer();
        }
        else if(distance <= 2 && canAttack && !PlayerHealth.PH.isDead)
        {
            
            agent.updateRotation = false;
            Vector3 direction = target.position - transform.position;
            direction.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);


            agent.updatePosition = false;
            anim.SetBool("isWalking", false);
            anim.SetBool("Attack", true);
        }
        else if(distance > 10)
        {
            StopChase();
        }
    }

    void ChasePlayer()
    {
        agent.updateRotation = true;
        agent.updatePosition = true;
        agent.SetDestination(target.position);
        anim.SetBool("isWalking", true);
        anim.SetBool("Attack", false);
    }

    

    void AttackPlayer()
    {
        PlayerHealth.PH.DamagePlayer(damage);
       
    }


    void StopChase()
    {
        agent.updatePosition = false;
        anim.SetBool("isWalking", false);
        anim.SetBool("Attack", false);
    }

    public void Hurt()
    {

        anim.SetTrigger("Hit");
        StartCoroutine(Nav());
    }
    public void DeadAnim()
    {
        isDead = true;
        anim.SetTrigger("Dead");
    }



    IEnumerator Nav()
    {
        yield return new WaitForSeconds(0.75f);

    }

   

}

   

    

