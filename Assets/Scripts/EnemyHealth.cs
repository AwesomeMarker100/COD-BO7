using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int maxHits = 25;


    public void ReduceHealth(int weaponDMG)
    {

        maxHits -= weaponDMG;
        BroadcastMessage("GotShot");

        if (maxHits <= 0)
        {

            GetComponent<Animator>().SetTrigger("Death");
            BroadcastMessage("StopEnemyAI");
            enabled = false;

        }

    }
   
}
