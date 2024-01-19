using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{    // Start is called before the first frame update

    Transform target;
    [SerializeField] int targetRange = 5;
    int lookSpeed = 5;

    NavMeshAgent nma;
    bool isProvoked = false;

    float distance;
    [SerializeField] int damage;

    bool shot;

    void Start()
    {
        target = FindObjectOfType<PlayerMechanisms>().transform;
        nma = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {

        
       TestIfInRange();
       CheckIfProvoked();

        
        
    }

    void TestIfInRange()
    {

        distance = Vector3.Distance(target.position, transform.position);
        

        if (distance <= targetRange || shot)
        {
            shot = false;
            isProvoked = true;

        }
        else if(distance > targetRange && !shot)
        {

            isProvoked = false;

        }



    }

    void StopEnemyAI()
    {
        enabled = false;
        nma.enabled = false;

    }

    void CheckIfProvoked()
    {

        if (isProvoked)
        {
            
            EngageTarget();
        } else
        {

            GetComponent<Animator>().ResetTrigger("Move");
            GetComponent<Animator>().SetTrigger("Idle");

        }

    }

    void EngageTarget()
    {
       
        if (distance > nma.stoppingDistance)// if not close enough, just chase until you get close enough
        {
            
            ChaseTarget();


        }

        if(distance <= nma.stoppingDistance) //when enemy is close enough to you, attack
        {

            AttackTarget();

        }
        

    }

    public void GotShot()
    {

        shot = true;

    }

    void FaceTarget()
    {

        Vector3 direction = (transform.position - target.position).normalized; //doesn't record distance or magnitude just direction
        Quaternion rotatation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)); //assigning an angle rotation by looking at that direction
        transform.rotation = Quaternion.Slerp(transform.rotation, rotatation, Time.deltaTime * lookSpeed); //setting the  rotation, Quaternion.Slerp makes animation smooth

    }
    void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("IsAttacking", false);
        GetComponent<Animator>().SetTrigger("Move");



        nma.SetDestination(target.position);

    }

    void AttackTarget()
    {

        GetComponent<Animator>().ResetTrigger("Move");
        GetComponent<Animator>().SetBool("IsAttacking", true);
        

    }

    public void DecreasePH()
    {

        target.GetComponent<PlayerMechanisms>().DecreaseHealth(damage);

    }

    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, targetRange);

    }
}
