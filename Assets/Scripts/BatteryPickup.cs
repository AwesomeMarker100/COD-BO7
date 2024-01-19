using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//my own logic
public class BatteryPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        

        if(collision.gameObject.tag == "Player")
        {
            PlayerMechanisms pm = collision.gameObject.GetComponent<PlayerMechanisms>();
            FlashlightIntensityDegrader flash = pm.GetComponentInChildren<FlashlightIntensityDegrader>();

            flash.AddVoltage(Random.Range(2, 4));
            

        }

        Destroy(gameObject);

    }
}
